using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using eu.greenmaster.Examples;
using eu.greenmaster.Models.Factories;
using eu.greenmaster.Models.Helpers;
using eu.greenmaster.Models.Static.Object.Rendering;
using eu.greenmaster.Models.Static.Time.Durations;
using eu.greenmaster.Models.ViewModels;
using eu.greenmaster.Tests.Helpers;
using Microsoft.Extensions.Configuration;
using static eu.greenmaster.Models.Helpers.ImageConverter;

namespace eu.greenmaster.Tests.UnitTests.Factories.RenderingFactoryTests;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public class CreateRenderingShould
{
    private readonly IConfigurationRoot _configuration;
    private readonly IConfigurationSection? _renderSettings;
    private readonly int _maxHeightConfig;
    private readonly int _maxWidthConfig;
    private readonly Image _renderingImage;

    public CreateRenderingShould()
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile(@"appsettings.json", false, false)
            .AddEnvironmentVariables()
            .Build();
        _renderSettings = _configuration.GetSection("AppSettings").GetSection("Rendering");
        _maxHeightConfig = int.Parse(_renderSettings.GetSection("Image")["MaxHeight"]);
        _maxWidthConfig = int.Parse(_renderSettings.GetSection("Image")["MaxWidth"]);
        _renderingImage = FromBase64(Base64Examples.ImageSpecie);
    }
    
    [Fact]
    public async Task ThrowNullReferenceException_WhenImageIsNull()
    {
        await Assert.ThrowsAsync<NullReferenceException>(async () => _ = await RenderingFactory.Create(new RenderingViewModel() {ImageBase64 = null!}));
    }
    [Fact]
    public async Task ThrowArgumentException_WhenImageIsEmpty()
    {
        await Assert.ThrowsAsync<ArgumentException>(async () => _ = await RenderingFactory.Create(new RenderingViewModel() {ImageBase64 = String.Empty}));
    }
    [Fact]
    public async Task ThrowArgumentException_WhenImageIsWhiteSpace()
    {
        await Assert.ThrowsAsync<ArgumentException>(async () => _ = await RenderingFactory.Create(new RenderingViewModel() { ImageBase64 = "  "}));
    }
    [Fact]
    public async Task ThrowArgumentException_WhenImageIsNotBase64()
    {
        await Assert.ThrowsAsync<ArgumentException>(async () => _ = await RenderingFactory.Create(new RenderingViewModel() { ImageBase64 = "eehu#ee"}));
    }
    
    [Fact]
    public async Task ThrowArgumentOutOfRangeException_WhenIdInvalid()
    {
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => _ = await RenderingFactory.Create(new RenderingViewModel()
        {
            Id = -1,
            ImageBase64 = Base64Examples.ImageRendering
        }));
    }
    
    [Fact]
    public async Task SetImageToConvertedIFormFileImage_WhenImageFromViewModelNotNull()
    {
        var viewModel = new RenderingViewModel
        {
            Id = 1,
            Type = RenderingObjectType.Plant,
            Season = Season.Autumn,
            Image = FormFileConverter.FromBase64(Base64Examples.ImageRendering),
            ImageBase64 = Base64Examples.ImageRendering
        };
        
        var resultRendering = await RenderingFactory.Create(viewModel);
        
        var expected = Resize(_renderingImage, _maxWidthConfig, _maxHeightConfig);
        AssertObjects.AssertImageSize(expected, FromBase64(resultRendering.Image));
    }
    
    [Fact]
    public async Task SetImageToImageBase64_WhenImageFromViewModelNull()
    {
        var viewModel = new RenderingViewModel
        {
            Id = 1,
            Type = RenderingObjectType.Plant,
            Season = Season.Autumn,
            Image = null!,
            ImageBase64 = Base64Examples.ImageRendering
        };
        
        var resultRendering = await RenderingFactory.Create(viewModel);
        
        var expected = Resize(_renderingImage, _maxWidthConfig, _maxHeightConfig);
        AssertObjects.AssertImageSize(expected, FromBase64(resultRendering.Image));
    }
    
    [Fact]
    public async Task SetImageToImageWithMaxHeightFromConfig_WhenImageFromViewModelNotNull()
    {
        var viewModel = new RenderingViewModel
        {
            Id = 1,
            Type = RenderingObjectType.Plant,
            Season = Season.Autumn,
            Image = FormFileConverter.FromBase64(Base64Examples.ImageRendering),
            ImageBase64 = Base64Examples.ImageRendering
        };
        
        var resultRendering = await RenderingFactory.Create(viewModel);

        var actual = FromBase64(resultRendering.Image);
        AssertObjects.AssertImageSize(actual, _maxWidthConfig, _maxHeightConfig);
    } 
    
    [Fact]
    public async Task SetImageToImageWithMaxWidthFromConfig_WhenImageFromViewModelNotNull()
    {
        var viewModel = new RenderingViewModel
        {
            Id = 1,
            Type = RenderingObjectType.Plant,
            Season = Season.Autumn,
            Image = FormFileConverter.FromBase64(Base64Examples.ImageSpecie),
            ImageBase64 = Base64Examples.ImageSpecie
        };
        
        var resultRendering = await RenderingFactory.Create(viewModel);

        var actual = FromBase64(resultRendering.Image);
        AssertObjects.AssertImageSize(actual, _maxWidthConfig, _maxHeightConfig);
    }

    [Fact]
    public async Task SetId_WhenValidOrDefault()
    {
        var viewModel = new RenderingViewModel
        {
            Id = 122,
            Type = RenderingObjectType.Plant,
            Season = Season.Autumn,
            Image = FormFileConverter.FromBase64(Base64Examples.ImageSpecie),
            ImageBase64 = Base64Examples.ImageSpecie
        };
        
        var resultRendering = await RenderingFactory.Create(viewModel);
        
        Assert.Equal(viewModel.Id, resultRendering.Id);
    }
}