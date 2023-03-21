using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using Greenmaster_ASP.Models;
using Greenmaster_ASP.Models.ViewModels;
using Xunit;

namespace Greenmaster_ASP.Tests.Helpers;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public static class AssertObjects
{
    public static void AssertSpecie(Specie expected, Specie? actual)
    {
        Assert.NotNull(actual);
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.Genus, actual.Genus);
        Assert.Equal(expected.Species, actual.Species);
        Assert.Equal(expected.Cultivar, actual.Cultivar);
        Assert.Equal(expected.CommonNames, actual.CommonNames);
        Assert.Equal(expected.Description, actual.Description);
        Assert.Equal(expected.PlantType, actual.PlantType);
        Assert.Equal(expected.IsPoisonous, actual.IsPoisonous);
        Assert.Equal(expected.Cycle, actual.Cycle);
        Assert.Equal(expected.Description, actual.Description);
        Assert.Equal(expected.Shape, actual.Shape);
        //MaxDimensions
        Assert.Equal(expected.MaxHeight, actual.MaxHeight);
        Assert.Equal(expected.MaxWidth, actual.MaxWidth);
        //PlantRequirements
        Assert.Equal(expected.Sunlight, actual.Sunlight);
        Assert.Equal(expected.Water, actual.Water);
        Assert.Equal(expected.Climate, actual.Climate);
        //FlowerInfo
        Assert.Equal(expected.BloomPeriod, actual.BloomPeriod);
        Assert.Equal(expected.AttractsPollinators, actual.AttractsPollinators);
        Assert.Equal(expected.IsFragrant, actual.IsFragrant);
        Assert.Equal(expected.FlowerColors, actual.FlowerColors);
        Console.WriteLine(expected.Image);
        Console.WriteLine(actual.Image);
        Assert.StartsWith(expected.Image[..6], actual.Image);
    }
    public static void AssertSpecieViewModel(SpecieViewModel expected, SpecieViewModel? actual)
    {
        Assert.NotNull(actual);
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.Genus, actual.Genus);
        Assert.Equal(expected.Species, actual.Species);
        Assert.Equal(expected.Cultivar, actual.Cultivar);
        Assert.Equal(expected.CommonNames, actual.CommonNames);
        Assert.Equal(expected.Description, actual.Description);
        Assert.Equal(expected.Type, actual.Type);
        Assert.Equal(expected.IsPoisonous, actual.IsPoisonous);
        Assert.Equal(expected.Lifecycle, actual.Lifecycle);
        Assert.Equal(expected.Description, actual.Description);
        Assert.Equal(expected.Shape, actual.Shape);
        //MaxDimensions
        Assert.Equal(expected.MaxHeight, actual.MaxHeight);
        Assert.Equal(expected.MaxWidth, actual.MaxWidth);
        //PlantRequirements
        Assert.Equal(expected.Sunlight, actual.Sunlight);
        Assert.Equal(expected.Water, actual.Water);
        Assert.Equal(expected.Climate, actual.Climate);
        //FlowerInfo
        Assert.Equal(expected.BloomPeriod, actual.BloomPeriod);
        Assert.Equal(expected.AttractsPollinators, actual.AttractsPollinators);
        Assert.Equal(expected.IsFragrant, actual.IsFragrant);
        Assert.Equal(expected.FlowerColors, actual.FlowerColors);
        //Media
        AssertImage(expected.Image, actual.Image);
    }

    public static void AssertImage(Image expected, Image actual)
    {
        Assert.Equal(expected.Flags, actual.Flags);
        Assert.Equal(expected.Height, actual.Height);
        Assert.Equal(expected.Width, actual.Width);
        Assert.Equal(expected.RawFormat, actual.RawFormat);
        Assert.Equal(expected.HorizontalResolution, actual.HorizontalResolution);
        Assert.Equal(expected.VerticalResolution, actual.VerticalResolution);
    }
}