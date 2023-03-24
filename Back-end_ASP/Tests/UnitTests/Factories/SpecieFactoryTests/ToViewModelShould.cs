﻿using Greenmaster_ASP.Models.Extensions;
using Greenmaster_ASP.Models.Factories;
using Greenmaster_ASP.Models.ViewModels;
using Xunit;
using static Greenmaster_ASP.Tests.Helpers.AssertObjects;

namespace Greenmaster_ASP.Tests.UnitTests.Factories.SpecieFactoryTests;

public class ToViewModelShould : SpecieFactoryTestBase
{
    private readonly SpecieViewModel _specieViewModel;
    
    [Fact]
    public void ThrowArgumentNullException_WhenPassedSpecieNull()
    {
        Assert.Throws<ArgumentNullException>(() => SpecieFactory.ToViewModel(null!));
    }
    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenViewModelMaxHeightInvalid()
    {
        var invalidMaxHeightSpecie = SpecieStrelitzia.Clone();
        invalidMaxHeightSpecie.MaxHeight = -15;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.ToViewModel(invalidMaxHeightSpecie));
        invalidMaxHeightSpecie.MaxHeight = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.ToViewModel(invalidMaxHeightSpecie));
        invalidMaxHeightSpecie.MaxHeight = 150.1;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.ToViewModel(invalidMaxHeightSpecie));
    }
    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenViewModelMaxWidthInvalid()
    {
        var invalidMaxWidthSpecie = SpecieStrelitzia.Clone();
        invalidMaxWidthSpecie.MaxWidth = -15;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.ToViewModel(invalidMaxWidthSpecie));
        invalidMaxWidthSpecie.MaxWidth = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.ToViewModel(invalidMaxWidthSpecie));
        invalidMaxWidthSpecie.MaxWidth = 10.1;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.ToViewModel(invalidMaxWidthSpecie));
    }

    [Fact]
    public void ReturnCorrectModelOfSpecie_WhenViewModelValid()
    {
        var resultSpecieViewModel = SpecieFactory.ToViewModel(SpecieStrelitzia);
        
        AssertSpecieViewModel(SpecieViewModelStrelitzia, resultSpecieViewModel);
    }
    
    [Fact]
    public void ThrowArgumentException_WhenImageStringEmpty()
    {
        var invalidSpecie = SpecieStrelitzia.Clone();
        invalidSpecie.Image =String.Empty;
        Assert.Throws<ArgumentException>(() => SpecieFactory.ToViewModel(invalidSpecie));
    }
    
    [Fact]
    public void ThrowFormatException_WhenParsingToImageObjectFails()
    {
        var invalidSpecie = SpecieStrelitzia.Clone();
        invalidSpecie.Image = "jeiejieijieji";
        Assert.Throws<FormatException>(() => SpecieFactory.ToViewModel(invalidSpecie));
    }
    
    [Fact]
    public void KeepImageNull_AfterCreation()
    {
        var resultSpecieViewModel = SpecieFactory.ToViewModel(SpecieStrelitzia);
        Assert.Null(resultSpecieViewModel.Image);
    }
    
    [Fact]
    public void SetImageBase64_AfterCreation()
    {
        var resultSpecieViewModel = SpecieFactory.ToViewModel(SpecieStrelitzia);
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