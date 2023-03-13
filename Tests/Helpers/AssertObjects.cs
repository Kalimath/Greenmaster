using Greenmaster_ASP.Models;
using Greenmaster_ASP.Models.ViewModels;
using Xunit;

namespace Greenmaster_ASP.Tests.Helpers;

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
        Assert.Equal(expected.Cycle, actual.Cycle);
        Assert.Equal(expected.Description, actual.Description);
        Assert.Equal(expected.BloomPeriod, actual.BloomPeriod);
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
        Assert.Equal(expected.Lifecycle, actual.Lifecycle);
        Assert.Equal(expected.Description, actual.Description);
    }
}