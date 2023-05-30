using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using Greenmaster.Core.Helpers;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.ViewModels;

namespace Greenmaster.Core.Tests.Helpers;

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
        Assert.Equal(expected.MinimalTemperature, actual.MinimalTemperature);
        //FlowerInfo
        Assert.Equal(expected.BloomPeriod, actual.BloomPeriod);
        Assert.Equal(expected.AttractsPollinators, actual.AttractsPollinators);
        Assert.Equal(expected.IsFragrant, actual.IsFragrant);
        Assert.Equal(expected.FlowerColors, actual.FlowerColors);
        //Media
        AssertBase64(expected.Image, actual.Image);
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
        Assert.Equal(expected.PlantType, actual.PlantType);
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
        Assert.Equal(expected.MinimalTemperature, actual.MinimalTemperature);
        //FlowerInfo
        Assert.Equal(expected.BloomPeriod, actual.BloomPeriod);
        Assert.Equal(expected.AttractsPollinators, actual.AttractsPollinators);
        Assert.Equal(expected.IsFragrant, actual.IsFragrant);
        Assert.Equal(expected.FlowerColors, actual.FlowerColors);
        //Media
        Assert.Null(actual.Image);
        if (actual.ImageBase64 != null)
        {
            AssertBase64(expected.ImageBase64!, actual.ImageBase64);
        }
        
    }

    public static void AssertBase64(string expected, string actual)
    {
        const string errorMessagePrefix = "Could not assert to invalid '{nameof(expected)}' string";
        if (StringValidator.IsValidString(expected))
        {
            if (StringValidator.IsBase64String(expected))
            {
                Assert.StartsWith(expected[..6], actual);
            }
            else
            {
                throw new FormatException(errorMessagePrefix);
            }
        }
        else
        {
            throw new ArgumentException($"{errorMessagePrefix} (null,empty or whitespace)");
        }
        
    }

    public static void AssertImageSize(Image expected, Image actual)
    {
        Assert.NotNull(actual);
        Assert.Equal(expected.Height, actual.Height);
        Assert.Equal(expected.Width, actual.Width);
    }

    public static void AssertImageSize(Image resizedImage, int maxWidth, int maxHeight)
    {
        Assert.NotNull(resizedImage);
        Assert.True((maxHeight >= resizedImage.Height));
        Assert.True((maxWidth >= resizedImage.Width));
    }
}