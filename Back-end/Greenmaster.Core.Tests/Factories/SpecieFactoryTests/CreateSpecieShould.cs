using Greenmaster.Core.Helpers;
using Greenmaster.Core.Models.Extensions;
using Greenmaster.Core.Tests.Factories.Base;
using static Greenmaster.Core.Tests.Helpers.AssertObjects;

namespace Greenmaster.Core.Tests.Factories.SpecieFactoryTests;

public class CreateSpecieShould : SpecieFactoryTestBase
{
    [Fact]
    public async Task ThrowArgumentNullException_WhenPassedViewModelNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(async () => await SpecieFactory.Create(null!));
    }
    
    //test if SpecieFactory.Create throws an exception when viewmodel.Genus does not exist in PlantGenus
    [Fact]
    public async Task ThrowArgumentException_WhenGenusDoesInPlantGenus()
    {
        var invalidGenusSpecieViewModel = SpecieFactory.ToViewModel(SpecieStrelitzia.Clone());
        invalidGenusSpecieViewModel.Genus = "invalidGenus";
        
        await Assert.ThrowsAsync<ArgumentException>(async () => await SpecieFactory.Create(invalidGenusSpecieViewModel));
    }

    [Fact]
    public async Task ThrowArgumentOutOfRangeException_WhenViewModelMaxHeightInvalid()
    {
        var invalidMaxHeightSpecieViewModel = SpecieFactory.ToViewModel(SpecieStrelitzia.Clone());
        invalidMaxHeightSpecieViewModel.MaxHeight = -15;
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await SpecieFactory.Create(invalidMaxHeightSpecieViewModel));
        invalidMaxHeightSpecieViewModel.MaxHeight = 0;
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await SpecieFactory.Create(invalidMaxHeightSpecieViewModel));
        invalidMaxHeightSpecieViewModel.MaxHeight = 150.1;
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await SpecieFactory.Create(invalidMaxHeightSpecieViewModel));
    }
    
    [Fact]
    public async Task ThrowArgumentOutOfRangeException_WhenViewModelMaxWidthInvalid()
    {
        var invalidMaxWidthSpecieViewModel = SpecieFactory.ToViewModel(SpecieStrelitzia.Clone());
        invalidMaxWidthSpecieViewModel.MaxWidth = -15;
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await SpecieFactory.Create(invalidMaxWidthSpecieViewModel));
        invalidMaxWidthSpecieViewModel.MaxWidth = 0;
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await SpecieFactory.Create(invalidMaxWidthSpecieViewModel));
        invalidMaxWidthSpecieViewModel.MaxWidth = 10.1;
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await SpecieFactory.Create(invalidMaxWidthSpecieViewModel));
    }

    [Fact]
    public async Task ReturnCorrectModelOfSpecie_WhenViewModelValid()
    {
        var resultSpecie = await SpecieFactory.Create(SpecieViewModelStrelitzia);
        
        AssertSpecie(SpecieStrelitzia, resultSpecie);
    }
    [Fact]
    public async Task SetImageToConvertedFormFile_WhenFormFileImageNotNull()
    {
        var resultSpecie = await SpecieFactory.Create(SpecieViewModelStrelitzia);

        AssertBase64(resultSpecie.Image, (await FormFileConverter.ToBase64(SpecieViewModelStrelitzia.Image)));
    }
    
    [Fact]
    public async Task SetPlantTypeIdToIdOfViewModelPlantType()
    {
        var resultSpecie = await SpecieFactory.Create(SpecieViewModelStrelitzia);

        Assert.Equal(resultSpecie.PlantTypeId, SpecieViewModelStrelitzia.PlantType!.Id);
    }
    [Fact]
    public async Task ThrowArgumentNullException_WhenPlantTypeNull()
    {
        var invalidSpecieViewModel = SpecieFactory.ToViewModel(SpecieStrelitzia.Clone());
        invalidSpecieViewModel.PlantType = null!;
        await Assert.ThrowsAsync<ArgumentNullException>( () => SpecieFactory.Create(invalidSpecieViewModel));
    }
    
    [Fact]
    public async Task ThrowNullReferenceException_WhenImageAndImageBase64AreNull()
    {
        var invalidSpecieViewModel = SpecieFactory.ToViewModel(SpecieStrelitzia.Clone());
        invalidSpecieViewModel.Image = null!;
        invalidSpecieViewModel.ImageBase64 = null!;
        await Assert.ThrowsAsync<NullReferenceException>( () => SpecieFactory.Create(invalidSpecieViewModel));
    }
    
    [Fact]
    public async Task SetImageToImageBase64_WhenImageFromViewModelNull()
    {
        var missingImageSpecieViewModel = SpecieFactory.ToViewModel(SpecieStrelitzia.Clone());
        missingImageSpecieViewModel.ImageBase64 = SpecieStrelitzia.Image;
        missingImageSpecieViewModel.Image = null!;
        var resultSpecie = await SpecieFactory.Create(missingImageSpecieViewModel);
        AssertBase64(resultSpecie.Image, missingImageSpecieViewModel.ImageBase64);
    }
    
    /*[Fact]
    public void ThrowInvalidOperationException_WhenParsingToImageObjectFails()
    {
        var invalidSpecieViewModel = SpecieViewModelStrelitzia.Clone();
        invalidSpecieViewModel.Image = Substitute.For<IFormFile>();
        invalidSpecieViewModel.Image.CopyTo(Arg.Any<Stream>()).th;
        Assert.Throws<InvalidOperationException>(() => SpecieFactory.Create(invalidSpecieViewModel));
    }*/
    
    //TODO: check if plantrequirements are created correctly
    //TODO: check if flowerData is created correctly
    //TODO: check if FertiliserData is created correctly
    
}