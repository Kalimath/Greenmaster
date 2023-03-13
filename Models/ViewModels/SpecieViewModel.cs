using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Greenmaster_ASP.Models.Static.Geographic;
using Greenmaster_ASP.Models.Static.Gradation;
using Greenmaster_ASP.Models.Static.Object.Organic;
using static Greenmaster_ASP.Models.Static.Object.Organic.PlantType;
using Greenmaster_ASP.Models.StaticData.Time.Durations;

namespace Greenmaster_ASP.Models.ViewModels;

public class SpecieViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Specie must have a genus.")]
    public string Genus { get; set; }

    [Required(ErrorMessage = "Specie must have a species.")]
    public string Species { get; set; }

    public string? Cultivar { get; set; }

    [Required(ErrorMessage = "Specie must have a PlantType")]
    [DisplayName("Plant-type")]
    public string Type { get; set; }

    public PlantType GetPlantType => GetByName(Type);

    [Required(ErrorMessage = "Specie must have a Lifecycle")]
    public Lifecycle Lifecycle { get; set; }

    [DisplayName("Scientific name")]
    public string ScientificName => $"{Genus} {Species}" + (string.IsNullOrEmpty(Cultivar) ? "" : $" '{Cultivar}'");

    [DisplayName("Common Names (separated by a comma)")]
    public string CommonNames { get; set; }

    [DisplayName("Info")] public string Description { get; set; }

    //PlantRequirements
    [Required]
    [DisplayName("Sunlight requirement")]
    public Amount Sunlight { get; set; }

    [Required]
    [DisplayName("Water requirement")]
    public Amount Water { get; set; }

    [Required]
    [DisplayName("Preferred climate")]
    public ClimateType Climate { get; set; }

    //MaxDimensions
    [Required(ErrorMessage = "Specie must have a max. height.")]
    [DisplayName("Maximum height (metric)")]
    [Range(0.1, 150, ErrorMessage = "Max. height is invalid.")]
    public double MaxHeight { get; set; }

    [Required(ErrorMessage = "Specie must have a max. width.")]
    [DisplayName("Maximum width (metric)")]
    [Range(0.1, 10, ErrorMessage = "Max. width is invalid.")]
    public double MaxWidth { get; set; }

    [DisplayName(displayName: "Months of blooming")]
    public Month[] BloomPeriod { get; set; } = { Month.NotSet };


    /*[Required]
    [DisplayName("Preferred soil type")]
    public SoilType Soil { get; set; }
    
    //FertiliserData
    [DisplayName("Requires lime")]
    public bool RequiresLime { get; set; }
    [DisplayName("Nitrogen percentage")]
    [Range(1,99, ErrorMessage = "Nitrogen percentage is invalid.")]
    public int NitrogenLevel { get; set; }
    [DisplayName("Phosphor percentage")]
    [Range(1,99, ErrorMessage = "Phosphor percentage is invalid.")]
    public int PhosphorLevel { get; set; }
    [DisplayName("Potassium percentage")]
    [Range(1,99, ErrorMessage = "Potassium percentage is invalid.")]
    public int PotassiumLevel { get; set; }
    
    //FlowerData
    [DisplayName("Flower color")]
    public Color Color { get; set; } = Color.Green;
    [DisplayName("Fragrant flowers")]
    public bool IsFragrant { get; set; }
    [DisplayName("Flowers attract bees and butterflies")]
    public bool AttractsPollinators { get; set; }
    
    
    */
}