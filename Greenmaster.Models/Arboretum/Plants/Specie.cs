using System.ComponentModel;
using Greenmaster.Models.Base;
using Greenmaster.Models.Enums.characteristics;
using Greenmaster.Models.Enums.Durations;

namespace Greenmaster.Models.Arboretum.Plants;

public class Specie : BaseEntity
{
    private string _scientificName;
    private string _commonName;
    private string _shape;

    [DisplayName("Scientific name")]
    public string ScientificName
    {
        get => _scientificName;
        set => _scientificName = value ?? throw new ArgumentNullException(nameof(value));
    }

    [DisplayName("Common name")]
    public string CommonName
    {
        get => _commonName;
        set
        {
            if (!AtLeastOneNameNotNullOrEmpty(ScientificName, CommonName))
                throw new ArgumentException("Scientific- or Common name needs to be filled in", nameof(value));
            _commonName = value ?? throw new ArgumentNullException(nameof(value));
        }
    }

    public string Shape
    {
        get => _shape;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Shape needs to be filled in", nameof(value));
            _shape = value;
        }
    }
    public Guid Id { get; set; }
    public PeriodOfYear FruitingPeriod { get; set; }
    public string HardinessZone { get; set; } = null!;
    public PlantType Type { get; set; }
    public LifeCycle LifeCycle { get; set; }
    public Toxicity Toxicity { get; set; }
    public FruitType Fruit { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    public Attractant Attractant { get; set; }
    public MaintenanceLevel MaintenanceLevel { get; set; }

    private bool AtLeastOneNameNotNullOrEmpty(string? name1, string? name2)
    {
        return !(string.IsNullOrEmpty(name1) && string.IsNullOrEmpty(name2));
    }
}