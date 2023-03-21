using System.Diagnostics.CodeAnalysis;
using Greenmaster_ASP.Models.Static.Geographic;
using Greenmaster_ASP.Models.Static.Gradation;
using Greenmaster_ASP.Models.Static.Object.Organic;
using Greenmaster_ASP.Models.Static.PlantProperties;
using Greenmaster_ASP.Models.StaticData.Time.Durations;
using Color = Greenmaster_ASP.Models.Static.Color;

namespace Greenmaster_ASP.Models;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public static class SpecieExamples
{
    private static readonly string Base64Image = "R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw==";
    public static readonly Specie Strelitzia = new Specie()
    {
        Id = 1,
        Genus = "Strelitzia",
        Species = "Reginae",
        Cultivar = "",
        CommonNames = "Bird of paradise,Paradijsvogelbloem",
        Description = "some text.",
        PlantType = PlantType.SmallShrub.Name,
        Shape = Shape.Vase,
        Cycle = Lifecycle.Perennial,
        Sunlight = Amount.Average,
        Water = Amount.Little,
        Climate = ClimateType.Tropical,
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
        FlowerColors = new[] { Color.Blue.ToString(), Color.MultiColor.ToString(), Color.Orange.ToString() },
        Image = Base64Image
    };

    public static readonly Specie Papaver = new Specie()
    {
        Id = 2,
        Genus = "Papaver",
        Species = "Orientale",
        Cultivar = "Catherina",
        CommonNames = "Eastern poppy,Oosterse papaver",
        Description = "Beautiful straight plant",
        PlantType = PlantType.SmallShrub.Name,
        Shape = Shape.Columnar,
        Cycle = Lifecycle.Annual,
        Sunlight = Amount.Many,
        Water = Amount.Little,
        Climate = ClimateType.Temperate,
        MaxHeight = 1,
        MaxWidth = 0.25,
        BloomPeriod = new[] { Month.May.ToString(), Month.June.ToString() },
        AttractsPollinators = true,
        IsFragrant = false,
        IsPoisonous = false,
        FlowerColors = new[] { Color.Pink.ToString() },
        Image = Base64Image
    };


    public static List<Specie> All()
    {
        return new List<Specie>()
        {
            Strelitzia,Papaver
        };
    }
}