using System.ComponentModel.DataAnnotations.Schema;

namespace Greenmaster_ASP.Models;

public class Location
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LocationId { get; set; }

    public double X { get; set; }
    public double Y { get; set; }
}