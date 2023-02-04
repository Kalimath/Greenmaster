using System.ComponentModel.DataAnnotations.Schema;

namespace Greenmaster_ASP.Models;

public class Area
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AreaId { get; set; }

    public string Name { get; set; }
    public bool IsOccupied { get; set; }
    public List<Location> EdgePoints { get; set; }

    public int DomainId { get; set; }
    public Domain Domain { get; set; }
}