using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster_ASP.Models.Static;
using Greenmaster_ASP.Models.Static.Geographic;
using Greenmaster_ASP.Models.Static.Gradation;
using Greenmaster_ASP.Models.Static.Object.Organic;
using static Greenmaster_ASP.Models.Static.Object.Organic.PlantType;

namespace Greenmaster_ASP.Models;

public class Specie
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }

    [Required] public string Genus { get; set; }
    [Required] public string Species { get; set; }
    public string? Cultivar { get; set; }
    public string ScientificName => $"{Genus} {Species}" + (string.IsNullOrEmpty(Cultivar) ? "" : $" '{Cultivar}'");

    public string CommonNames { get; set; }
    public string Description { get; set; }

    [Required] public string PlantType { get; set; }

    public PlantType GetPlantType => GetByName(PlantType);

    public bool IsPoisonous { get; set; }

    [Required] public Lifecycle Cycle { get; set; }


    //PlantRequirements
    public Amount Sunlight { get; set; }
    public Amount Water { get; set; }
    public ClimateType Climate { get; set; }

    //MaxDimensions
    [Required] public double MaxHeight { get; set; }
    [Required] public double MaxWidth { get; set; }
    
    //FlowerInfo
    public string[] BloomPeriod { get; set; }
    public string[]? FlowerColors { get; set; }
    public bool IsFragrant { get; set; }
    public bool AttractsPollinators { get; set; }
}