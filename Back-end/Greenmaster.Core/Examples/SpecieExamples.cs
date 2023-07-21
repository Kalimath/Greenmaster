using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using Greenmaster.Core.Models;
using StaticData.Geographic;
using StaticData.Gradation;
using StaticData.Object.Organic;
using StaticData.PlantProperties;
using StaticData.Taxonomy;
using StaticData.Time.Durations;

namespace Greenmaster.Core.Examples;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public static class SpecieExamples 
{
    public static readonly Specie Strelitzia = new()
    {
        Id = 1,
        Genus = PlantGenus.Strelitzia,
        Species = "Reginae",
        Cultivar = "",
        CommonNames = "Bird of paradise,Paradijsvogelbloem",
        Description = "some text.",
        PlantTypeId = ObjectTypeExamples.SmallShrub.Id,
        Shape = Shape.Vase,
        Cycle = Lifecycle.Perennial,
        Sunlight = Amount.Average,
        Water = Amount.Little,
        Climate = ClimateType.Tropical,
        MinimalTemperature = 10,
        MaxHeight = 2.5,
        MaxWidth = 0.75,
        BloomPeriod = new[]
        {
            Month.May, 
            Month.June, 
            Month.July, 
            Month.August,
            Month.September, 
            Month.October
        },
        PollinatingFlowers = true,
        IsFragrant = false,
        IsPoisonous = true,
        MutualisticGenera = Array.Empty<PlantGenus>(),
        FlowerColors = new[] { Color.Blue, Color.Orange },
        Image = Base64Examples.ImageSpecie
    };

    public static readonly Specie Papaver = new()
    {
        Id = 2,
        Genus = PlantGenus.Papaver,
        Species = "Orientale",
        Cultivar = "Catherina",
        CommonNames = "Eastern poppy, Oosterse papaver",
        Description = "Beautiful straight plant",
        PlantTypeId = ObjectTypeExamples.SmallShrub.Id,
        Shape = Shape.Columnar,
        Cycle = Lifecycle.Annual,
        Sunlight = Amount.Many,
        Water = Amount.Little,
        Climate = ClimateType.Temperate,
        MinimalTemperature = -2,
        MaxHeight = 1,
        MaxWidth = 0.25,
        BloomPeriod = new[] { Month.May, Month.June },
        PollinatingFlowers = true,
        IsFragrant = false,
        IsPoisonous = false,
        MutualisticGenera =  new[] { PlantGenus.Aster},
        FlowerColors = new[] { Color.Pink },
        Image = Base64Examples.ImageSpecie
    };
    
    public static readonly Specie Aster = new()
    {
        Id = 3,
        Genus = PlantGenus.Aster,
        Species = "Maritimus",
        CommonNames = "Gele zeeaster",
        Description = "Een licht vorstgevoelige verhoutende vaste plant die bij ons eenjarige gekweekt wordt. " +
                      "Kan dus overgehouden worden en het jaar nadien terug in de border uitgeplant worden.",
        PlantTypeId = ObjectTypeExamples.SmallShrub.Id,
        Shape = Shape.NotSet,
        Cycle = Lifecycle.Annual,
        Sunlight = Amount.Many,
        Water = Amount.Average,
        Climate = ClimateType.Mediterranean,
        MinimalTemperature = -2,
        MaxHeight = 0.2,
        MaxWidth = 0.2,
        BloomPeriod = new []
        {
            Month.May, 
            Month.June, 
            Month.July, 
            Month.August,
            Month.September
        },
        PollinatingFlowers = true,
        IsFragrant = false,
        IsPoisonous = false,
        MutualisticGenera =  new[] { PlantGenus.Papaver},
        FlowerColors = new[] { Color.Yellow },
        Image = Base64Examples.ImageSpecie
    };
    
    public static List<Specie> GetAll()
    {
        return new List<Specie>()
        {
            Strelitzia,
            Papaver, 
            Aster
        };
    }
}