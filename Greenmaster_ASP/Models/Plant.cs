using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster_ASP.Models.Measurements;
using Greenmaster_ASP.Models.StaticData.Object.Organic;

namespace Greenmaster_ASP.Models;

public class Plant : Placeable
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PlantId { get; set; }
    
    public virtual PlantDimensions Dimensions { get; set; }
    public virtual Specie Specie { get; set; }
    public PlantType Type { get; set; }
}