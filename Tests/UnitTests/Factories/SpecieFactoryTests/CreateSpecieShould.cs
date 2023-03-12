/*using Greenmaster_ASP.Models.Factories;
using Greenmaster_ASP.Models.Static;
using Greenmaster_ASP.Models.Static.Geographic;
using Greenmaster_ASP.Models.Static.Gradation;
using Greenmaster_ASP.Models.Static.Object.Organic;
using Greenmaster_ASP.Models.StaticData;
using Greenmaster_ASP.Models.StaticData.Time.Durations;
using Greenmaster_ASP.Models.ViewModels;
using Xunit;

namespace Greenmaster_ASP.Tests.UnitTests.Factories.SpecieFactoryTests;

public class CreateSpecieShould
{
    private readonly SpecieViewModel _specieViewModel;

    public CreateSpecieShould()
    {
        _specieViewModel = new SpecieViewModel()
        {
            SpecieId = 15215,
            ScientificName = "Strelitsia Reginae",
            Lifecycle = Lifecycle.Perennial,
            Climate = ClimateType.Tropical,
            Color = Color.Green,
            Soil = SoilType.Sandy,
            Sunlight = Amount.Average,
            Water = Amount.Little,
            FlowerPeriod = new List<Month>() { Month.August,Month.September },
            AttractsPollinators = true,
            IsFragrant = false,
            RequiresLime = false,
            MaxHeight = 1.2,
            MaxWidth = 0.75,
            NitrogenLevel = 20,
            PhosphorLevel = 30,
            PotassiumLevel = 50
            
        };
    }
    
    [Fact]
    public void ThrowArgumentNullException_WhenPassedViewModelNull()
    {
        Assert.Throws<ArgumentNullException>(() => SpecieFactory.Create(null!));
    }
    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenViewModelMaxHeightInvalid()
    {
        _specieViewModel.MaxHeight = -15;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(_specieViewModel));
        _specieViewModel.MaxHeight = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(_specieViewModel));
        _specieViewModel.MaxHeight = 50.1;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(_specieViewModel));
    }
    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenViewModelMaxWidthInvalid()
    {
        _specieViewModel.MaxWidth = -15;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(_specieViewModel));
        _specieViewModel.MaxWidth = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(_specieViewModel));
        _specieViewModel.MaxWidth = 10.1;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(_specieViewModel));
    }

    [Fact]
    public void ThrowArgumentOutOfRangeException_WhenCombinedNPPLevelsNotEqualTo100Percent()
    {
        _specieViewModel.NitrogenLevel += 6;
        Assert.Throws<ArgumentOutOfRangeException>(() => SpecieFactory.Create(_specieViewModel));
    }
    
    //TODO: check if plantrequirements are created correctly
    //TODO: check if dimensions are created correctly
    //TODO: check if specie is created correctly
    //TODO: check if flowerData is created correctly
    //TODO: check if FertiliserData is created correctly
}*/