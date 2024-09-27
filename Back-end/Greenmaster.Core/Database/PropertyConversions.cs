using System.Drawing;
using Greenmaster.Core.Extensions;
using Greenmaster.Core.Models;
using Microsoft.EntityFrameworkCore;
using StaticData.Geographic;
using StaticData.Gradation;
using StaticData.Object.Organic;
using StaticData.Object.Rendering;
using StaticData.PlantProperties;
using StaticData.Taxonomy;
using StaticData.Time.Durations;

namespace Greenmaster.Core.Database;

public static class PropertyConversions
{
    public static void PlantTypeConverters(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlantType>()
            .Property(e => e.Canopy)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<Permeability>(v));
    }

    public static void RenderingConverters(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rendering>()
            .Property(e => e.Season)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<Season>(v));
        modelBuilder.Entity<Rendering>()
            .Property(e => e.Type)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<RenderingObjectType>(v));
    }

    public static void GardenStyleConverters(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GardenStyle>()
            .Property(e => e.SuitablePlantGenera)
            .HasConversion(
                v => string.Join(',', v.Select(x => x.ToString())),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Enum.Parse<PlantGenus>).ToArray());
        modelBuilder.Entity<GardenStyle>()
            .Property(e => e.Colors)
            .HasConversion(
                v => string.Join(',', v.Select(x => x.Hex)),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(hex => hex.ToColor()).ToArray());
        modelBuilder.Entity<GardenStyle>()
            .Property(e => e.Concepts)
            .HasConversion(
                v => string.Join(',', v.Select(x => x.ToString())),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        modelBuilder.Entity<GardenStyle>()
            .Property(e => e.Shapes)
            .HasConversion(
                v => string.Join(',', v.Select(x => x.ToString())),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
    }

    public static void SpecieConverters(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Specie>()
            .Property(e => e.Genus)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<PlantGenus>(v));
        modelBuilder.Entity<Specie>()
            .Property(e => e.BloomPeriod)
            .HasConversion(
                v => string.Join(',', v.Select(x => x.ToString())),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Enum.Parse<Month>).ToArray());
        modelBuilder.Entity<Specie>()
            .Property(e => e.MutualisticGenera)
            .HasConversion(
                v => string.Join(',', v.Select(x => x.ToString())),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Enum.Parse<PlantGenus>).ToArray());
        modelBuilder.Entity<Specie>()
            .Property(e => e.FlowerColors)
            .HasConversion(
                v => string.Join(',', v.Select(color => color.Hex)),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(hex => hex.ToColor()).ToArray());
        modelBuilder.Entity<Specie>()
            .Property(e => e.Cycle)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<Lifecycle>(v));
        modelBuilder.Entity<Specie>()
            .Property(e => e.Shape)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<Shape>(v));
        modelBuilder.Entity<Specie>()
            .Property(e => e.Sunlight)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<Amount>(v));
        modelBuilder.Entity<Specie>()
            .Property(e => e.Water)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<Amount>(v));
        modelBuilder.Entity<Specie>()
            .Property(e => e.Climate)
            .HasConversion(
                v => v.ToString(),
                v => Enum.Parse<ClimateType>(v));
    }
}