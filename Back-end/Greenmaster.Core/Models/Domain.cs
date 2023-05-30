using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster.Core.Models.Placeables;

namespace Greenmaster.Core.Models;

public class Domain
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DomainId { get; set; }
    public int OwnerId { get; set; }
    public List<Placeable> Placeables { get; set; }
    public List<Area> Areas { get; set; }
}