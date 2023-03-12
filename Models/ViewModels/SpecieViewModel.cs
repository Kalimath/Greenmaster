using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Greenmaster_ASP.Models.Static.Object.Organic;

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
    public string Type { get; set; }
    
    [Required(ErrorMessage = "Specie must have a Lifecycle")]
    public Lifecycle Lifecycle { get; set; }
    
    public string ScientificName => $"{Genus} {Species}" + (string.IsNullOrEmpty(Cultivar) ? "" : $" '{Cultivar}'");
    
    public string CommonNames { get; set; }
    
    public string Description { get; set; }
    
    //MaxDimensions
    [Required(ErrorMessage = "Specie must have a max. height.")]
    [DisplayName("Maximum height (metric)")]
    [Range(0.1, 150, ErrorMessage = "Max. height is invalid.")]
    public double MaxHeight { get; set; }
    
    [Required(ErrorMessage = "Specie must have a max. width.")]
    [DisplayName("Maximum width (metric)")]
    [Range(0.1, 10, ErrorMessage = "Max. width is invalid.")]
    public double MaxWidth { get; set; }

    /*//PlantRequirements
    [Required]
    [DisplayName("Sunlight requirement")]
    public Amount Sunlight { get; set; }
    [Required]
    [DisplayName("Water requirement")]
    public Amount Water { get; set; }
    [Required]
    [DisplayName("Preferred climate")]
    public ClimateType Climate { get; set; }
    [Required]
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
    [DisplayName("Months with flowers")] 
    public List<Month> FlowerPeriod { get; set; } = new List<Month>();
    [DisplayName("Fragrant flowers")]
    public bool IsFragrant { get; set; }
    [DisplayName("Flowers attract bees and butterflies")]
    public bool AttractsPollinators { get; set; }
    
    
    */
}