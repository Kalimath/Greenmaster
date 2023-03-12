using Greenmaster_ASP.Models;
using Greenmaster_ASP.Models.Factories;
using Greenmaster_ASP.Models.Static.Object.Organic;
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
        _specieStrelitzia.MaxHeight = -15;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.ToViewModel(_specieStrelitzia));
        _specieStrelitzia.MaxHeight = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.ToViewModel(_specieStrelitzia));
        _specieStrelitzia.MaxHeight = 150.1;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.ToViewModel(_specieStrelitzia));
    }
    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenViewModelMaxWidthInvalid()
    {
        _specieStrelitzia.MaxWidth = -15;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.ToViewModel(_specieStrelitzia));
        _specieStrelitzia.MaxWidth = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.ToViewModel(_specieStrelitzia));
        _specieStrelitzia.MaxWidth = 10.1;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.ToViewModel(_specieStrelitzia));
    }

    [Fact]
    public void ReturnCorrectModelOfSpecie_WhenViewModelValid()
    {
        var resultSpecieViewModel = SpecieFactory.ToViewModel(_specieStrelitzia);
        
        AssertSpecieViewModel(_specieViewModelStrelitzia, resultSpecieViewModel);
    }

    /*[Fact]
    public void ThrowArgumentOutOfRangeException_WhenCombinedNPPLevelsNotEqualTo100Percent()
    {
        _specieViewModel.NitrogenLevel += 6;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(_specieViewModel));
    }*/
    
    //TODO: check if plantrequirements are created correctly
    //TODO: check if flowerData is created correctly
    //TODO: check if FertiliserData is created correctly
}