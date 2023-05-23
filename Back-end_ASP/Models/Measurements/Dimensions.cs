using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Greenmaster_ASP.Models.Measurements;

public class Dimensions
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }
    public double Length { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
}