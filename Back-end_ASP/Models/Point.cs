using System.ComponentModel.DataAnnotations.Schema;

namespace Greenmaster_ASP.Models;

public class Point
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
}