using eu.greenmaster.Models.Extensions;
using eu.greenmaster.Models.Factories;
using eu.greenmaster.Models.ViewModels;
using static eu.greenmaster.Tests.Helpers.AssertObjects;
// ReSharper disable StringLiteralTypo

namespace eu.greenmaster.Tests.UnitTests.Mappers.SpecieMapperTests;

public class MapViewModelShould : SpecieFactoryTestBase
{
    private readonly SpecieViewModel _specieViewModel;
    
    [Fact]
    public void ThrowArgumentNullException_WhenPassedSpecieNull()
    {
        Assert.Throws<ArgumentNullException>(() => SpecieMapper.MapSpecieViewModel(null!));
    }
    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenViewModelMaxHeightInvalid()
    {
        var invalidMaxHeightSpecie = SpecieStrelitzia.Clone();
        invalidMaxHeightSpecie.MaxHeight = -15;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieMapper.MapSpecieViewModel(invalidMaxHeightSpecie));
        invalidMaxHeightSpecie.MaxHeight = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieMapper.MapSpecieViewModel(invalidMaxHeightSpecie));
        invalidMaxHeightSpecie.MaxHeight = 150.1;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieMapper.MapSpecieViewModel(invalidMaxHeightSpecie));
    }
    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenViewModelMaxWidthInvalid()
    {
        var invalidMaxWidthSpecie = SpecieStrelitzia.Clone();
        invalidMaxWidthSpecie.MaxWidth = -15;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieMapper.MapSpecieViewModel(invalidMaxWidthSpecie));
        invalidMaxWidthSpecie.MaxWidth = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieMapper.MapSpecieViewModel(invalidMaxWidthSpecie));
        invalidMaxWidthSpecie.MaxWidth = 10.1;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieMapper.MapSpecieViewModel(invalidMaxWidthSpecie));
    }

    [Fact]
    public void ReturnCorrectModelOfSpecie_WhenViewModelValid()
    {
        var resultSpecieViewModel = SpecieMapper.MapSpecieViewModel(SpecieStrelitzia);
        
        AssertSpecieViewModel(SpecieViewModelStrelitzia, resultSpecieViewModel);
    }
    
    [Fact]
    public void ThrowArgumentException_WhenImageStringEmpty()
    {
        var invalidSpecie = SpecieStrelitzia.Clone();
        invalidSpecie.Image =String.Empty;
        Assert.Throws<ArgumentException>(() => SpecieMapper.MapSpecieViewModel(invalidSpecie));
    }
    
    [Fact]
    public void ThrowFormatException_WhenParsingToImageObjectFails()
    {
        var invalidSpecie = SpecieStrelitzia.Clone();
        invalidSpecie.Image = "jeiejieijieji";
        Assert.Throws<FormatException>(() => SpecieMapper.MapSpecieViewModel(invalidSpecie));
    }
    
    [Fact]
    public void KeepImageNull_AfterCreation()
    {
        var resultSpecieViewModel = SpecieMapper.MapSpecieViewModel(SpecieStrelitzia);
        Assert.Null(resultSpecieViewModel.Image);
    }
    
    [Fact]
    public void SetImageBase64_AfterCreation()
    {
        var resultSpecieViewModel = SpecieMapper.MapSpecieViewModel(SpecieStrelitzia);
        Assert.NotNull(resultSpecieViewModel.ImageBase64);
        AssertBase64(SpecieStrelitzia.Image, resultSpecieViewModel.ImageBase64);
    }

    /*[Fact]
    public void ThrowArgumentOutOfRangeException_WhenCombinedNPPLevelsNotEqualTo100Percent()
    {
        _specieViewModel.NitrogenLevel += 6;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieMapper.MapSpecieCreate(_specieViewModel));
    }*/
    
}