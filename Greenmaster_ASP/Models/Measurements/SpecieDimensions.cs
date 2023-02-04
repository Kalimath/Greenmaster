using System.ComponentModel.DataAnnotations.Schema;

namespace Greenmaster_ASP.Models.Measurements;

public class SpecieDimensions
{
    [ForeignKey(nameof(Specie))]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SpecieDimensionsId { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
}