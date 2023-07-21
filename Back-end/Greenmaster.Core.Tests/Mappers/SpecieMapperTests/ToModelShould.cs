using Greenmaster.Core.Examples;
using Greenmaster.Core.Extensions;
using Greenmaster.Core.Helpers;
using Greenmaster.Core.Tests.Mappers.Base;
using StaticData.Taxonomy;
using static Greenmaster.Core.Tests.Helpers.AssertObjects;

namespace Greenmaster.Core.Tests.Mappers.SpecieMapperTests;

public class ToModelShould : SpecieMapperTestBase
{
    [Fact]
    public async Task ThrowArgumentNullException_WhenPassedViewModelNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(async () => await SpecieMapper.ToModel(null!));
    }
    
    //test if SpecieFactory.Create throws an exception when viewmodel.Genus does not exist in PlantGenus
    [Fact]
    public async Task ThrowArgumentException_WhenGenusDoesInPlantGenus()
    {
        var invalidGenusSpecieViewModel = SpecieMapper.ToViewModel(SpecieStrelitzia.Clone());
        invalidGenusSpecieViewModel.Genus = "invalidGenus";
        
        await Assert.ThrowsAsync<ArgumentException>(async () => await SpecieMapper.ToModel(invalidGenusSpecieViewModel));
    }

    [Fact]
    public async Task ThrowArgumentOutOfRangeException_WhenViewModelMaxHeightInvalid()
    {
        var invalidMaxHeightSpecieViewModel = SpecieMapper.ToViewModel(SpecieStrelitzia.Clone());
        invalidMaxHeightSpecieViewModel.MaxHeight = -15;
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await SpecieMapper.ToModel(invalidMaxHeightSpecieViewModel));
        invalidMaxHeightSpecieViewModel.MaxHeight = 0;
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await SpecieMapper.ToModel(invalidMaxHeightSpecieViewModel));
        invalidMaxHeightSpecieViewModel.MaxHeight = 150.1;
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await SpecieMapper.ToModel(invalidMaxHeightSpecieViewModel));
    }
    
    [Fact]
    public async Task ThrowArgumentOutOfRangeException_WhenViewModelMaxWidthInvalid()
    {
        var invalidMaxWidthSpecieViewModel = SpecieMapper.ToViewModel(SpecieStrelitzia.Clone());
        invalidMaxWidthSpecieViewModel.MaxWidth = -15;
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await SpecieMapper.ToModel(invalidMaxWidthSpecieViewModel));
        invalidMaxWidthSpecieViewModel.MaxWidth = 0;
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await SpecieMapper.ToModel(invalidMaxWidthSpecieViewModel));
        invalidMaxWidthSpecieViewModel.MaxWidth = 10.1;
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await SpecieMapper.ToModel(invalidMaxWidthSpecieViewModel));
    }

    [Fact]
    public async Task ReturnCorrectModelOfSpecie_WhenViewModelValid()
    {
        var resultSpecie = await SpecieMapper.ToModel(SpecieViewModelStrelitzia);
        
        AssertSpecie(SpecieStrelitzia, resultSpecie);
    }

    [Fact]
    public async Task ReturnEmptyMutualisticGenera_WhenViewModelHasNoMutualisticGenera()
    {
        var specieViewModel = SpecieMapper.ToViewModel(SpecieStrelitzia.Clone());
        specieViewModel.MutualisticGenera = Array.Empty<PlantGenus>();
        var resultSpecie = await SpecieMapper.ToModel(specieViewModel);
        
        Assert.Empty(resultSpecie.MutualisticGenera);
    }

    [Fact]
    public async Task ReturnExpectedMutualisticGenera_WhenViewModelHasMutualisticGenera()
    {
        var specieViewModel = SpecieMapper.ToViewModel(SpecieStrelitzia.Clone());
        var mutualisticGenera = new [] { PlantGenus.Agapanthus };
        specieViewModel.MutualisticGenera = mutualisticGenera;
        var resultSpecie = await SpecieMapper.ToModel(specieViewModel);
        
        Assert.Equal(mutualisticGenera, resultSpecie.MutualisticGenera);
    }
    
    [Fact]
    public async Task SetImageToConvertedFormFile_WhenFormFileImageNotNull()
    {
        var resultSpecie = await SpecieMapper.ToModel(SpecieViewModelStrelitzia);

        AssertBase64(resultSpecie.Image, (await FormFileConverter.ToBase64(SpecieViewModelStrelitzia.Image)));
    }
    
    [Fact]
    public async Task SetPlantTypeIdToIdOfViewModelPlantType()
    {
        var resultSpecie = await SpecieMapper.ToModel(SpecieViewModelStrelitzia);

        Assert.Equal(resultSpecie.PlantTypeId, SpecieViewModelStrelitzia.PlantType!.Id);
    }
    [Fact]
    public async Task ThrowArgumentNullException_WhenPlantTypeNull()
    {
        var invalidSpecieViewModel = SpecieMapper.ToViewModel(SpecieStrelitzia.Clone());
        invalidSpecieViewModel.PlantType = null!;
        await Assert.ThrowsAsync<ArgumentNullException>( () => SpecieMapper.ToModel(invalidSpecieViewModel));
    }
    
    [Fact]
    public async Task ThrowNullReferenceException_WhenImageAndImageBase64AreNull()
    {
        var invalidSpecieViewModel = SpecieMapper.ToViewModel(SpecieStrelitzia.Clone());
        invalidSpecieViewModel.Image = null!;
        invalidSpecieViewModel.ImageBase64 = null!;
        await Assert.ThrowsAsync<NullReferenceException>( () => SpecieMapper.ToModel(invalidSpecieViewModel));
    }
    
    [Fact]
    public async Task SetImageToImageBase64_WhenImageFromViewModelNull()
    {
        var missingImageSpecieViewModel = SpecieMapper.ToViewModel(SpecieStrelitzia.Clone());
        missingImageSpecieViewModel.ImageBase64 = SpecieStrelitzia.Image;
        missingImageSpecieViewModel.Image = null!;
        var resultSpecie = await SpecieMapper.ToModel(missingImageSpecieViewModel);
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