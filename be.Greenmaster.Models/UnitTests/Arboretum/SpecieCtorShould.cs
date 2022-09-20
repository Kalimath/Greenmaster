using System.Collections.Concurrent;
using be.Greenmaster.Extensions.SubTypes;
using be.Greenmaster.Models.Arboretum;
using be.Greenmaster.Models.StaticData;
using Xunit;
using Xunit.Abstractions;

namespace be.Greenmaster.Models.UnitTests.Arboretum;

public class SpecieCtorShould
{
    
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly string _validCommonNameNl;
    private readonly string _validScientificName;
    private readonly DictionaryEnum<Language, string> _validCommonNames;
    private readonly PlantProperties _validPlantProperties;
    private readonly Language _language = Language.Nl;
    
    public SpecieCtorShould(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _validScientificName = "Strelitzia reginae";
        _validCommonNameNl = "Paradijsvogelbloem";
        _validCommonNames = new DictionaryEnum<Language, string>();
        _validPlantProperties = new PlantProperties(false);
    }

    [Fact]
    public void SetScientificNameCorrectlyWhenNotNullOrEmpty()
    {
        var validScientificName = "Strelitzia reginae";
        Specie validSpecie = new Specie(validScientificName);
        Assert.Equal(validScientificName, validSpecie.ScientificName);
    }

    [Fact]
    public void ThrowArgumentExceptionWhenScientificNameEmpty()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var badSpecie = new Specie("");
        });
    }

    [Fact]
    public void SetCommonNamesCorrectlyWhenNotNullOrEmpty()
    {
        _validCommonNames[_language.ToString()] = _validCommonNameNl;
        Specie validSpecie = new Specie(_validScientificName, _validCommonNames, _validPlantProperties);
        _testOutputHelper.WriteLine(_validCommonNames[_language.ToString()]);
        Assert.Equal(_validCommonNameNl, validSpecie.CommonNames?[_language.ToString()]);
    }

    [Fact]
    public void ThrowArgumentNullExceptionWhenCommonNamesSetEmpty()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var badSpecie = new Specie(_validScientificName, _validCommonNames, new PlantProperties(false));
            _testOutputHelper.WriteLine(_validCommonNames[_language.ToString()]);
        });
    }

}