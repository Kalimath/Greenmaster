using Greenmaster.Core.Extensions;
using Greenmaster.Core.Tests.Mappers.Base;
using StaticData.Taxonomy;
using static Greenmaster.Core.Tests.Helpers.AssertObjects;

namespace Greenmaster.Core.Tests.Mappers.SpecieMapperTests;

public class ToViewModelShould : SpecieMapperTestBase
{
    // private readonly SpecieViewModel _specieViewModel;
    
    [Fact]
    public void ThrowArgumentNullException_WhenPassedSpecieNull()
    {
        Assert.Throws<ArgumentNullException>(() => SpecieMapper.ToViewModel(null!));
    }
    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenViewModelMaxHeightInvalid()
    {
        var invalidMaxHeightSpecie = SpecieStrelitzia.Clone();
        invalidMaxHeightSpecie.MaxHeight = -15;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieMapper.ToViewModel(invalidMaxHeightSpecie));
        invalidMaxHeightSpecie.MaxHeight = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieMapper.ToViewModel(invalidMaxHeightSpecie));
        invalidMaxHeightSpecie.MaxHeight = 150.1;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieMapper.ToViewModel(invalidMaxHeightSpecie));
    }
    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenViewModelMaxWidthInvalid()
    {
        var invalidMaxWidthSpecie = SpecieStrelitzia.Clone();
        invalidMaxWidthSpecie.MaxWidth = -15;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieMapper.ToViewModel(invalidMaxWidthSpecie));
        invalidMaxWidthSpecie.MaxWidth = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieMapper.ToViewModel(invalidMaxWidthSpecie));
        invalidMaxWidthSpecie.MaxWidth = 10.1;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieMapper.ToViewModel(invalidMaxWidthSpecie));
    }

    [Fact]
    public void ReturnCorrectModelOfSpecie_WhenViewModelValid()
    {
        var resultSpecieViewModel = SpecieMapper.ToViewModel(SpecieStrelitzia);
        
        AssertSpecieViewModel(SpecieViewModelStrelitzia, resultSpecieViewModel);
    }
    
    [Fact]
    public async Task ReturnEmptyMutualisticGenera_WhenViewModelHasNoMutualisticGenera()
    {
        var specie = SpecieStrelitzia.Clone();
        var mutualisticGenera = Array.Empty<PlantGenus>();
        specie.MutualisticGenera = mutualisticGenera;
        var viewModel = SpecieMapper.ToViewModel(specie);
        
        Assert.Empty(viewModel.MutualisticGenera);
    }

    [Fact]
    public async Task ReturnExpectedMutualisticGenera_WhenViewModelHasMutualisticGenera()
    {
        var specie = SpecieStrelitzia.Clone();
        var mutualisticGenera = new [] { PlantGenus.Agapanthus };
        specie.MutualisticGenera = mutualisticGenera;
        var viewModel = SpecieMapper.ToViewModel(specie);
        
        Assert.Equal(mutualisticGenera, viewModel.MutualisticGenera);
    }
    
    [Fact]
    public void ThrowArgumentException_WhenImageStringEmpty()
    {
        var invalidSpecie = SpecieStrelitzia.Clone();
        invalidSpecie.Image =string.Empty;
        Assert.Throws<ArgumentException>(() => SpecieMapper.ToViewModel(invalidSpecie));
    }
    
    [Fact]
    public void ThrowFormatException_WhenParsingToImageObjectFails()
    {
        var invalidSpecie = SpecieStrelitzia.Clone();
        invalidSpecie.Image = "jeiejieijieji";
        Assert.Throws<FormatException>(() => SpecieMapper.ToViewModel(invalidSpecie));
    }
    
    [Fact]
    public void KeepImageNull_AfterCreation()
    {
        var resultSpecieViewModel = SpecieMapper.ToViewModel(SpecieStrelitzia);
        Assert.Null(resultSpecieViewModel.Image);
    }
    
    [Fact]
    public void SetImageBase64_AfterCreation()
    {
        var resultSpecieViewModel = SpecieMapper.ToViewModel(SpecieStrelitzia);
        Assert.NotNull(resultSpecieViewModel.ImageBase64);
        AssertBase64(SpecieStrelitzia.Image, resultSpecieViewModel.ImageBase64);
    }

    /*[Fact]
    public void ThrowArgumentOutOfRangeException_WhenCombinedNPPLevelsNotEqualTo100Percent()
    {
        _specieViewModel.NitrogenLevel += 6;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(_specieViewModel));
    }*/
    
}