using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StaticData.Geographic;
using StaticData.Gradation;

namespace Greenmaster.Core.Models;

public class PlantRequirements
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int PlantRequirementsId { get; set; }

    public Amount Sunlight { get; set; }
    public Amount Water { get; set; }
    public ClimateType Climate { get; set; }
    public SoilType Soil { get; set; }
    
    
    public int FertiliserInfoId { get; set; }
    public FertiliserData FertiliserInfo { get; set; }
}