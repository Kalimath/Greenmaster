using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Greenmaster_ASP.Models.StaticData;
using Greenmaster_ASP.Models.StaticData.Geographic;
using Greenmaster_ASP.Models.StaticData.Gradation;
using Greenmaster_ASP.Models.StaticData.Object.Organic;
using Greenmaster_ASP.Models.StaticData.Time.Durations;

namespace Greenmaster_ASP.Models.ViewModels;

public class SpecieViewModel
{
    public int SpecieId { get; set; }
    [Required(ErrorMessage = "Specie must have a scientific name.")]
    [DisplayName("Scientific name")]
    [MinLength(4, ErrorMessage = "Scientific name is too short.")]
    public string ScientificName { get; set; }
    [Required]
    public Lifecycle Lifecycle { get; set; }
    
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
    
    //MaxDimensions
    [Required(ErrorMessage = "Specie must have a max. height.")]
    [DisplayName("Max. height in metres")]
    [Range(0.1, 50, ErrorMessage = "Max. height is invalid.")]
    public double MaxHeight { get; set; }
    [Required(ErrorMessage = "Specie must have a max. width.")]
    [DisplayName("Max. width in metres")]
    [Range(0.1, 10, ErrorMessage = "Max. width is invalid.")]
    public double MaxWidth { get; set; }
}