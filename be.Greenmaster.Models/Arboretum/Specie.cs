using System.ComponentModel.DataAnnotations;
using be.Greenmaster.Extensions;
using be.Greenmaster.Extensions.Methods;
using be.Greenmaster.Extensions.SubTypes;
using be.Greenmaster.Models.StaticData;

namespace be.Greenmaster.Models.Arboretum;

public class Specie
{
    [MinLength(3)] [MaxLength(20)] public string ScientificName { get; private set; }

    public DictionaryEnum<Language, string>? CommonNames { get; set; }
    public PlantProperties Properties { get; set; }

    public Specie(string scientificName, DictionaryEnum<Language, string> commonNames, PlantProperties properties)
    {
        ScientificName = !string.IsNullOrWhiteSpace(scientificName)
            ? scientificName
            : throw new ArgumentException(nameof(scientificName));
        CommonNames = commonNames;
        Properties = properties;
    }

    public Specie(string scientificName) : this(scientificName, new DictionaryEnum<Language, string>(), null!)
    {
    }
}