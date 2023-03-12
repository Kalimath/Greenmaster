using Greenmaster_ASP.Models.Factories;
using Xunit;
using static Greenmaster_ASP.Tests.Helpers.AssertObjects;

namespace Greenmaster_ASP.Tests.UnitTests.Factories.SpecieFactoryTests;

public class CreateSpecieShould : SpecieFactoryTestBase
{
    
    
    [Fact]
    public void ThrowArgumentNullException_WhenPassedViewModelNull()
    {
        Assert.Throws<ArgumentNullException>(() => SpecieFactory.Create(null!));
    }
    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenViewModelMaxHeightInvalid()
    {
        _specieViewModelStrelitzia.MaxHeight = -15;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(_specieViewModelStrelitzia));
        _specieViewModelStrelitzia.MaxHeight = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(_specieViewModelStrelitzia));
        _specieViewModelStrelitzia.MaxHeight = 150.1;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(_specieViewModelStrelitzia));
    }
    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenViewModelMaxWidthInvalid()
    {
        _specieViewModelStrelitzia.MaxWidth = -15;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(_specieViewModelStrelitzia));
        _specieViewModelStrelitzia.MaxWidth = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(_specieViewModelStrelitzia));
        _specieViewModelStrelitzia.MaxWidth = 10.1;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(_specieViewModelStrelitzia));
    }

    [Fact]
    public void ReturnCorrectModelOfSpecie_WhenViewModelValid()
    {
        var resultSpecie = SpecieFactory.Create(_specieViewModelStrelitzia);
        
        AssertSpecie(_specieStrelitzia, resultSpecie);
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