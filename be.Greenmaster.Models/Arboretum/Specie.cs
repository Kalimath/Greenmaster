using System.ComponentModel.DataAnnotations;
using be.Greenmaster.Models.StaticData;

namespace be.Greenmaster.Models.Arboretum;

public class Specie
{
    [MinLength(3)]
    [MaxLength(20)]
    public string ScientificName { get; private set; }

    public IDictionary<Language,string>? CommonNames { get; set; }
    public Specie.Properties Attributes { get; set; }

    public Specie(string scientificName, IDictionary<Language, string>? commonNames, Properties attributes)
    {
        ScientificName = !string.IsNullOrWhiteSpace(scientificName) ? scientificName : throw new ArgumentException(nameof(scientificName));
        CommonNames = commonNames;
        Attributes = attributes;
        
    }

    public Specie(string scientificName) : this(scientificName, new Dictionary<Language, string>(), new Properties())
    {
        
    }

    public class Properties
    {
    }
}