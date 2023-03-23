using Greenmaster_ASP.Models.Examples;
using Greenmaster_ASP.Models.Factories;
using Greenmaster_ASP.Models.Static.Object.Rendering;
using Greenmaster_ASP.Models.Static.Time.Durations;
using Greenmaster_ASP.Models.ViewModels;
using Greenmaster_ASP.Tests.Helpers;
using Xunit;
using static Greenmaster_ASP.Helpers.FormFileConverter;

namespace Greenmaster_ASP.Tests.UnitTests.Factories.RenderingFactoryTests;

public class CreateRenderingShould
{
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
            ImageBase64 = Base64Examples.ImageSpecie
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
            Image = FromBase64(Base64Examples.ImageSpecie),
            ImageBase64 = Base64Examples.ImageSpecie
        };
        
        var resultRendering = await RenderingFactory.Create(viewModel);
        
        AssertObjects.AssertBase64(resultRendering.Image, await ToBase64(viewModel.Image));
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
    [Fact]
    public async Task SetImageToImageBase64_WhenImageFromViewModelNull()
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
        
        AssertObjects.AssertBase64(resultRendering.Image, viewModel.ImageBase64);
    }
}