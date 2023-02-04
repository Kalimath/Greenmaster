using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster_ASP.Models.Measurements;
using Greenmaster_ASP.Models.StaticData.Object.Organic;

namespace Greenmaster_ASP.Models;

[Table("Plant")]
public class Plant : Placeable
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PlantId { get; set; }

    public int DimensionsId { get; set; }
    public virtual Dimensions DesiredDimensions { get; set; }
    
    public int SpecieId { get; set; }
    public virtual Specie Specie { get; set; }
    
    public PlantType Type { get; set; }
    
    public int? LocationId { get; set; }
    public Location? Position { get; set; }
}