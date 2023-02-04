using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster_ASP.Models.StaticData.Geographic;
using Greenmaster_ASP.Models.StaticData.Gradation;

namespace Greenmaster_ASP.Models;

public class PlantRequirements
{
    [ForeignKey(nameof(Specie))]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int RequirementsId { get; set; }

    public Amount Sunlight { get; set; }
    public Amount Water { get; set; }
    public ClimateType Climate { get; set; }
    public SoilType Soil { get; set; }
    public virtual FertiliserData FertiliserInfo { get; set; }
}