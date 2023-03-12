using Greenmaster_ASP.Models;
using Greenmaster_ASP.Models.Static.Object.Organic;
using Greenmaster_ASP.Models.StaticData.Time.Durations;
using Greenmaster_ASP.Models.ViewModels;

namespace Greenmaster_ASP.Tests.UnitTests.Factories.SpecieFactoryTests;

public class SpecieFactoryTestBase
{
    protected SpecieViewModel _specieViewModelStrelitzia;
    protected Specie _specieStrelitzia;
    private readonly Month[] _bloomPeriod;

    public SpecieFactoryTestBase()
    {
        _bloomPeriod = new [] { Month.May , Month.June, Month.July, Month.August, Month.September, Month.October};
        
        _specieViewModelStrelitzia = new SpecieViewModel()
        {
            Id = 1,
            Genus = "Strelitzia",
            Species = "Reginae",
            Cultivar = "",
            CommonNames = "Bird of paradise,Paradijsvogelbloem",
            Description = "some text.",
            Type = PlantType.SmallShrub.Name,
            Lifecycle = Lifecycle.Perennial,
            MaxHeight = 23.5,
            MaxWidth = 4.5,
            BloomPeriod = _bloomPeriod
            
        };
        var stringifiedBloomPeriod = new string[_bloomPeriod.Length];
        for (var index = 0; index < _bloomPeriod.Length; index++)
        {
            stringifiedBloomPeriod[index] = _bloomPeriod[index].ToString();
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
            Cycle = _specieViewModelStrelitzia.Lifecycle,
            MaxHeight = _specieViewModelStrelitzia.MaxHeight,
            MaxWidth = _specieViewModelStrelitzia.MaxWidth,
            BloomPeriod = stringifiedBloomPeriod
        };
    }
}