using Greenmaster_ASP.Models;
using Greenmaster_ASP.Models.Examples;
using Greenmaster_ASP.Models.Static;
using Greenmaster_ASP.Models.StaticData.Time.Durations;
using Greenmaster_ASP.Models.ViewModels;
using static Greenmaster_ASP.Helpers.FormFileConverter;
using SpecieExamples = Greenmaster_ASP.Models.Examples.SpecieExamples;

namespace Greenmaster_ASP.Tests.UnitTests.Factories.SpecieFactoryTests;

public class SpecieFactoryTestBase
{
    protected SpecieViewModel SpecieViewModelStrelitzia;
    protected Specie SpecieStrelitzia;

    public SpecieFactoryTestBase()
    {
        
        SpecieViewModelStrelitzia = new SpecieViewModel()
        {
            Id = 1,
            Genus = SpecieExamples.Strelitzia.Genus,
            Species = SpecieExamples.Strelitzia.Species,
            Cultivar = SpecieExamples.Strelitzia.Cultivar,
            CommonNames = SpecieExamples.Strelitzia.CommonNames,
            Description = SpecieExamples.Strelitzia.Description,
            Type = SpecieExamples.Strelitzia.PlantType,
            Shape = SpecieExamples.Strelitzia.Shape,
            Lifecycle = SpecieExamples.Strelitzia.Cycle,
            Sunlight = SpecieExamples.Strelitzia.Sunlight,
            Water = SpecieExamples.Strelitzia.Water,
            Climate = SpecieExamples.Strelitzia.Climate,
            MinimalTemperature = SpecieExamples.Strelitzia.MinimalTemperature,
            MaxHeight = SpecieExamples.Strelitzia.MaxHeight,
            MaxWidth = SpecieExamples.Strelitzia.MaxWidth,
            BloomPeriod = SpecieExamples.Strelitzia.BloomPeriod.Select(s => Enum.Parse<Month>(s)).ToArray(),
            AttractsPollinators = SpecieExamples.Strelitzia.AttractsPollinators,
            IsFragrant = SpecieExamples.Strelitzia.IsFragrant,
            IsPoisonous = SpecieExamples.Strelitzia.IsPoisonous,
            FlowerColors =SpecieExamples.Strelitzia.FlowerColors!.Select(s => Enum.Parse<Color>(s)).ToArray(),
            Image = FromBase64(Base64Examples.ImageSpecie),
            ImageBase64 = SpecieExamples.Strelitzia.Image
        };

        SpecieStrelitzia = SpecieExamples.Strelitzia;
    }

    
}