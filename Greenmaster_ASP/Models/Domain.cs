using System.ComponentModel.DataAnnotations.Schema;

namespace Greenmaster_ASP.Models;

public class Domain
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DomainId { get; set; }
    public int OwnerId { get; set; }
    public List<Placeable> Placeables { get; set; }
    public List<Area> Areas { get; set; }
}