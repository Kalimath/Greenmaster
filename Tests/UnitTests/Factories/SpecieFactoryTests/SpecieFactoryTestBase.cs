using Greenmaster_ASP.Models;
using Greenmaster_ASP.Models.Static;
using Greenmaster_ASP.Models.Static.Geographic;
using Greenmaster_ASP.Models.Static.Gradation;
using Greenmaster_ASP.Models.Static.Object.Organic;
using Greenmaster_ASP.Models.Static.PlantProperties;
using Greenmaster_ASP.Models.StaticData.Time.Durations;
using Greenmaster_ASP.Models.ViewModels;

namespace Greenmaster_ASP.Tests.UnitTests.Factories.SpecieFactoryTests;

public class SpecieFactoryTestBase
{
    protected SpecieViewModel _specieViewModelStrelitzia;
    protected Specie _specieStrelitzia;

    public SpecieFactoryTestBase()
    {
        var bloomPeriod = new [] { Month.May , Month.June, Month.July, Month.August, Month.September, Month.October};
        
        _specieViewModelStrelitzia = new SpecieViewModel()
        {
            Id = 1,
            Genus = "Strelitzia",
            Species = "Reginae",
            Cultivar = "",
            CommonNames = "Bird of paradise,Paradijsvogelbloem",
            Description = "some text.",
            Type = PlantType.SmallShrub.Name,
            Shape = Shape.Vase,
            Lifecycle = Lifecycle.Perennial,
            Sunlight = Amount.Average,
            Water = Amount.Little,
            Climate = ClimateType.Tropical,
            MaxHeight = 2.5,
            MaxWidth = 0.75,
            BloomPeriod = bloomPeriod,
            AttractsPollinators = true,
            IsFragrant = false,
            IsPoisonous = true,
            FlowerColors = new [] { Color.Blue , Color.MultiColor,Color.Orange}
            
        };
        var stringifiedBloomPeriod = new string[bloomPeriod.Length];
        for (var index = 0; index < bloomPeriod.Length; index++)
        {
            stringifiedBloomPeriod[index] = bloomPeriod[index].ToString();
        }

        _specieStrelitzia = new Specie
        {
            Id = _specieViewModelStrelitzia.Id,
            Genus = _specieViewModelStrelitzia.Genus,
            Species = _specieViewModelStrelitzia.Species,
            Cultivar = _specieViewModelStrelitzia.Cultivar,
            CommonNames = _specieViewModelStrelitzia.CommonNames,
            Description = _specieViewModelStrelitzia.Description,
            PlantType = _specieViewModelStrelitzia.Type,
            IsPoisonous = _specieViewModelStrelitzia.IsPoisonous,
            Cycle = _specieViewModelStrelitzia.Lifecycle,
            Shape = _specieViewModelStrelitzia.Shape,
            Sunlight = _specieViewModelStrelitzia.Sunlight,
            Water = _specieViewModelStrelitzia.Water,
            MaxHeight = _specieViewModelStrelitzia.MaxHeight,
            MaxWidth = _specieViewModelStrelitzia.MaxWidth,
            BloomPeriod = _specieViewModelStrelitzia.BloomPeriod.Select(a => a.ToString()).ToArray(),
            FlowerColors = _specieViewModelStrelitzia.FlowerColors.Select(a => a.ToString()).ToArray(),
            IsFragrant =_specieViewModelStrelitzia.IsFragrant,
            AttractsPollinators = _specieViewModelStrelitzia.AttractsPollinators,
            Climate = _specieViewModelStrelitzia.Climate,

        };
    }
}