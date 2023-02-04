using System.ComponentModel.DataAnnotations.Schema;

namespace Greenmaster_ASP.Models.Measurements;

public class PlantDimensions
{
    [ForeignKey(nameof(Plant))]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PlantDimensionsId { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
}