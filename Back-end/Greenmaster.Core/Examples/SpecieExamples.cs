using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.Extensions;
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
        Id = Guid.NewGuid(),
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
        Climate = ClimateType.Mediterranean,
        MinimalTemperature = 10,
        MaxHeight = 2.5,
        MaxWidth = 0.75,
        BloomPeriod = new[]
        {
            Month.May.ToString(), Month.June.ToString(), Month.July.ToString(), Month.August.ToString(),
            Month.September.ToString(), Month.October.ToString()
        },
        AttractsPollinators = true,
        IsFragrant = false,
        IsPoisonous = true,
        FlowerColors = new[] { Color.Blue, Color.Orange }.GetNames().ToArray(),
        Image = Base64Examples.ImageSpecie
    };

    public static readonly Specie Papaver = new()
    {
        Id = Guid.NewGuid(),
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
        BloomPeriod = new[] { Month.May.ToString(), Month.June.ToString() },
        AttractsPollinators = true,
        IsFragrant = false,
        IsPoisonous = false,
        FlowerColors = new[] { Color.Pink.GetName() },
        MutualisticGenera =  new[] { PlantGenus.Aster},
        Image = Base64Examples.ImageSpecie
    };

    public static readonly Specie Aster = new()
    {
        Id = Guid.NewGuid(),
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
        BloomPeriod = new[]
        {
            Month.May.ToString(), 
            Month.June.ToString(), 
            Month.July.ToString(), 
            Month.August.ToString(),
            Month.September.ToString()
        },
        AttractsPollinators = true,
        IsFragrant = false,
        IsPoisonous = false,
        FlowerColors = new[] { Color.Yellow.GetName() },
        MutualisticGenera =  new[] { PlantGenus.Papaver },
        Image = Base64Examples.ImageSpecie
    };

    public static List<Specie> GetAll()
    {
        return new List<Specie>()
        {
            Strelitzia,Papaver
        };
    }
}