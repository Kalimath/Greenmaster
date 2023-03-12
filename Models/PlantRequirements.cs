using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster_ASP.Models.Static.Geographic;
using Greenmaster_ASP.Models.Static.Gradation;

namespace Greenmaster_ASP.Models;

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