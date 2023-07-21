using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using Greenmaster.Core.Examples;
using Greenmaster.Core.Models.ViewModels;
using Greenmaster.Core.Tests.Helpers;
using Greenmaster.Core.Tests.Mappers.Base;
using StaticData.Object.Rendering;
using StaticData.Time.Durations;
using static Greenmaster.Core.Helpers.FormFileConverter;
using ImageConverter = Greenmaster.Core.Helpers.ImageConverter;

namespace Greenmaster.Core.Tests.Mappers.RenderingMapperTests;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public class ToModelShould : RenderingMapperTestBase
{
    private readonly Image _renderingImage;
    

    public ToModelShould()
    {
        _renderingImage = ImageConverter.FromBase64(Base64Examples.ImageSpecie);
    }
    
    [Fact]
    public async Task ThrowNullReferenceException_WhenImageIsNull()
    {
        await Assert.ThrowsAsync<NullReferenceException>(async () => _ = await RenderingMapper.ToModel(new RenderingViewModel() {ImageBase64 = null!}));
    }
    [Fact]
    public async Task ThrowArgumentException_WhenImageIsEmpty()
    {
        await Assert.ThrowsAsync<ArgumentException>(async () => _ = await RenderingMapper.ToModel(new RenderingViewModel() {ImageBase64 = string.Empty}));
    }
    [Fact]
    public async Task ThrowArgumentException_WhenImageIsWhiteSpace()
    {
        await Assert.ThrowsAsync<ArgumentException>(async () => _ = await RenderingMapper.ToModel(new RenderingViewModel() { ImageBase64 = "  "}));
    }
    [Fact]
    public async Task ThrowArgumentException_WhenImageIsNotBase64()
    {
        await Assert.ThrowsAsync<ArgumentException>(async () => _ = await RenderingMapper.ToModel(new RenderingViewModel() { ImageBase64 = "eehu#ee"}));
    }
    
    [Fact]
    public async Task ThrowArgumentOutOfRangeException_WhenIdInvalid()
    {
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => _ = await RenderingMapper.ToModel(new RenderingViewModel()
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
        
        var resultRendering = await RenderingMapper.ToModel(viewModel);
        
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
        
        var resultRendering = await RenderingMapper.ToModel(viewModel);

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
        
        var resultRendering = await RenderingMapper.ToModel(viewModel);

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
        
        var resultRendering = await RenderingMapper.ToModel(viewModel);

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
        
        var resultRendering = await RenderingMapper.ToModel(viewModel);
        
        Assert.Equal(viewModel.Id, resultRendering.Id);
    }
}