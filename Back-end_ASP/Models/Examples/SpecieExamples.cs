﻿using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using Greenmaster_ASP.Models.Extensions;
using Greenmaster_ASP.Models.Static.Geographic;
using Greenmaster_ASP.Models.Static.Gradation;
using Greenmaster_ASP.Models.Static.Object.Organic;
using Greenmaster_ASP.Models.Static.PlantProperties;
using Greenmaster_ASP.Models.StaticData.Time.Durations;

namespace Greenmaster_ASP.Models.Examples;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public static class SpecieExamples 
{
    public static readonly Specie Strelitzia = new()
    {
        Id = 1,
        Genus = "Strelitzia",
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
            Month.May.ToString(), Month.June.ToString(), Month.July.ToString(), Month.August.ToString(),
            Month.September.ToString(), Month.October.ToString()
        },
        AttractsPollinators = true,
        IsFragrant = false,
        IsPoisonous = true,
        FlowerColors = new[] { Color.Blue.GetName(), Color.Orange.GetName() },
        Image = Base64Examples.ImageSpecie
    };

    public static readonly Specie Papaver = new()
    {
        Id = 2,
        Genus = "Papaver",
        Species = "Orientale",
        Cultivar = "Catherina",
        CommonNames = "Eastern poppy,Oosterse papaver",
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