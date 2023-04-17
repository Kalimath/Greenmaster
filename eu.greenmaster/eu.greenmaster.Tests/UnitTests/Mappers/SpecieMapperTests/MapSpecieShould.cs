using eu.greenmaster.Models.Extensions;
using eu.greenmaster.Models.Factories;
using eu.greenmaster.Models.Helpers;
using static eu.greenmaster.Tests.Helpers.AssertObjects;

namespace eu.greenmaster.Tests.UnitTests.Factories.SpecieFactoryTests;

public class MapSpecieShould : SpecieFactoryTestBase
{
    [Fact]
    public async Task ThrowArgumentNullException_WhenPassedViewModelNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(async () => await SpecieMapper.MapSpecie(null!));
    }
    
    [Fact]
    public async Task ThrowArgumentOutOfRangeException_WhenViewModelMaxHeightInvalid()
    {
        var invalidMaxHeightSpecieViewModel = SpecieMapper.MapSpecieViewModel(SpecieStrelitzia.Clone());
        invalidMaxHeightSpecieViewModel.MaxHeight = -15;
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await SpecieMapper.MapSpecie(invalidMaxHeightSpecieViewModel));
        invalidMaxHeightSpecieViewModel.MaxHeight = 0;
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await SpecieMapper.MapSpecie(invalidMaxHeightSpecieViewModel));
        invalidMaxHeightSpecieViewModel.MaxHeight = 150.1;
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await SpecieMapper.MapSpecie(invalidMaxHeightSpecieViewModel));
    }
    
    [Fact]
    public async Task ThrowArgumentOutOfRangeException_WhenViewModelMaxWidthInvalid()
    {
        var invalidMaxWidthSpecieViewModel = SpecieMapper.MapSpecieViewModel(SpecieStrelitzia.Clone());
        invalidMaxWidthSpecieViewModel.MaxWidth = -15;
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await SpecieMapper.MapSpecie(invalidMaxWidthSpecieViewModel));
        invalidMaxWidthSpecieViewModel.MaxWidth = 0;
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await SpecieMapper.MapSpecie(invalidMaxWidthSpecieViewModel));
        invalidMaxWidthSpecieViewModel.MaxWidth = 10.1;
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await SpecieMapper.MapSpecie(invalidMaxWidthSpecieViewModel));
    }

    [Fact]
    public async Task ReturnCorrectModelOfSpecie_WhenViewModelValid()
    {
        var resultSpecie = await SpecieMapper.MapSpecie(SpecieViewModelStrelitzia);
        
        AssertSpecie(SpecieStrelitzia, resultSpecie);
    }
    [Fact]
    public async Task SetImageToConvertedFormFile_WhenFormFileImageNotNull()
    {
        var resultSpecie = await SpecieMapper.MapSpecie(SpecieViewModelStrelitzia);

        AssertBase64(resultSpecie.Image, (await FormFileConverter.ToBase64(SpecieViewModelStrelitzia.Image)));
    }
    
    [Fact]
    public async Task SetPlantTypeIdToIdOfViewModelPlantType()
    {
        var resultSpecie = await SpecieMapper.MapSpecie(SpecieViewModelStrelitzia);

        Assert.Equal(resultSpecie.PlantTypeId, SpecieViewModelStrelitzia.PlantType.Id);
    }
    [Fact]
    public async Task ThrowArgumentNullException_WhenPlantTypeNull()
    {
        var invalidSpecieViewModel = SpecieMapper.MapSpecieViewModel(SpecieStrelitzia.Clone());
        invalidSpecieViewModel.PlantType = null!;
        await Assert.ThrowsAsync<ArgumentNullException>( () => SpecieMapper.MapSpecie(invalidSpecieViewModel));
    }
    
    [Fact]
    public async Task ThrowNullReferenceException_WhenImageAndImageBase64AreNull()
    {
        var invalidSpecieViewModel = SpecieMapper.MapSpecieViewModel(SpecieStrelitzia.Clone());
        invalidSpecieViewModel.Image = null!;
        invalidSpecieViewModel.ImageBase64 = null!;
        await Assert.ThrowsAsync<NullReferenceException>( () => SpecieMapper.MapSpecie(invalidSpecieViewModel));
    }
    
    [Fact]
    public async Task SetImageToImageBase64_WhenImageFromViewModelNull()
    {
        var missingImageSpecieViewModel = SpecieMapper.MapSpecieViewModel(SpecieStrelitzia.Clone());
        missingImageSpecieViewModel.ImageBase64 = SpecieStrelitzia.Image;
        missingImageSpecieViewModel.Image = null!;
        var resultSpecie = await SpecieMapper.MapSpecie(missingImageSpecieViewModel);
        AssertBase64(resultSpecie.Image, missingImageSpecieViewModel.ImageBase64);
    }
    
    /*[Fact]
    public void ThrowInvalidOperationException_WhenParsingToImageObjectFails()
    {
        var invalidSpecieViewModel = SpecieViewModelStrelitzia.Clone();
        invalidSpecieViewModel.Image = Substitute.For<IFormFile>();
        invalidSpecieViewModel.Image.CopyTo(Arg.Any<Stream>()).th;
        Assert.Throws<InvalidOperationException>(() => SpecieMapper.MapSpecie(invalidSpecieViewModel));
    }*/
    
    //TODO: check if plantrequirements are created correctly
    //TODO: check if flowerData is created correctly
    //TODO: check if FertiliserData is created correctly
    
}