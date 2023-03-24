using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Greenmaster_ASP.Models.Measurements;

public class Dimensions
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DimensionsId { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    
    public int? SpecieId { get; set; }
    public Specie Specie { get; set; }
    
    public int? PlantId { get; set; }
    public Plant Plant { get; set; }
}