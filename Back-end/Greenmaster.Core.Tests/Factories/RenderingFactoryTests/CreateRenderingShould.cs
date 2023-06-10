using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using Greenmaster.Core.Examples;
using Greenmaster.Core.Models.ViewModels;
using Greenmaster.Core.Tests.Factories.Base;
using Greenmaster.Core.Tests.Helpers;
using StaticData.Object.Rendering;
using StaticData.Time.Durations;
using static Greenmaster.Core.Helpers.FormFileConverter;
using ImageConverter = Greenmaster.Core.Helpers.ImageConverter;

namespace Greenmaster.Core.Tests.Factories.RenderingFactoryTests;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public class CreateRenderingShould : RenderingFactoryTestBase
{
    private readonly Image _renderingImage;
    

    public CreateRenderingShould()
    {
        _renderingImage = ImageConverter.FromBase64(Base64Examples.ImageSpecie);
    }
    
    [Fact]
    public async Task ThrowNullReferenceException_WhenImageIsNull()
    {
        await Assert.ThrowsAsync<NullReferenceException>(async () => _ = await RenderingFactory.Create(new RenderingViewModel() {ImageBase64 = null!}));
    }
    [Fact]
    public async Task ThrowArgumentException_WhenImageIsEmpty()
    {
        await Assert.ThrowsAsync<ArgumentException>(async () => _ = await RenderingFactory.Create(new RenderingViewModel() {ImageBase64 = string.Empty}));
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
            Image = FromBase64(Base64Examples.ImageRendering),
            ImageBase64 = Base64Examples.ImageRendering
        };
        
        var resultRendering = await RenderingFactory.Create(viewModel);
        
        AssertObjects.AssertImageSize(ImageConverter.FromBase64(resultRendering.Image), MaxWidthConfig, MaxHeightConfig);
    }
    
    [Fact]
    public async Task SetImageToImageBase64_WhenImageFromViewModelNull()
    {
        //mock resize config
        var imageRendering = ImageConverter.FromBase64(Base64Examples.ImageRendering);
        DefineConfigReturnValues(imageRendering.Height, imageRendering.Width);
        
        var viewModel = new RenderingViewModel
        {
            Id = 1,
            Type = RenderingObjectType.Plant,
            Season = Season.Autumn,
            Image = null!,
            ImageBase64 = Base64Examples.ImageRendering
        };
        
        var resultRendering = await RenderingFactory.Create(viewModel);

        var actual = ImageConverter.FromBase64(resultRendering.Image);
        AssertObjects.AssertImageSize(imageRendering, actual);
    }
    
    [Fact]
    public async Task SetImageToImageWithMaxHeightFromConfig_WhenImageFromViewModelNotNull()
    {
        var viewModel = new RenderingViewModel
        {
            Id = 1,
            Type = RenderingObjectType.Plant,
            Season = Season.Autumn,
            Image = FromBase64(Base64Examples.ImageRendering),
            ImageBase64 = Base64Examples.ImageRendering
        };
        
        var resultRendering = await RenderingFactory.Create(viewModel);

        var actual = ImageConverter.FromBase64(resultRendering.Image);
        AssertObjects.AssertImageSize(actual, MaxWidthConfig, MaxHeightConfig);
    } 
    
    [Fact]
    public async Task SetImageToImageWithMaxWidthFromConfig_WhenImageFromViewModelNotNull()
    {
        var viewModel = new RenderingViewModel
        {
            Id = 1,
            Type = RenderingObjectType.Plant,
            Season = Season.Autumn,
            Image = FromBase64(Base64Examples.ImageSpecie),
            ImageBase64 = Base64Examples.ImageSpecie
        };
        
        var resultRendering = await RenderingFactory.Create(viewModel);

        var actual = ImageConverter.FromBase64(resultRendering.Image);
        AssertObjects.AssertImageSize(actual, MaxWidthConfig, MaxHeightConfig);
    }

    [Fact]
    public async Task SetId_WhenValidOrDefault()
    {
        var viewModel = new RenderingViewModel
        {
            Id = 122,
            Type = RenderingObjectType.Plant,
            Season = Season.Autumn,
            Image = FromBase64(Base64Examples.ImageSpecie),
            ImageBase64 = Base64Examples.ImageSpecie
        };
        
        var resultRendering = await RenderingFactory.Create(viewModel);
        
        Assert.Equal(viewModel.Id, resultRendering.Id);
    }
}