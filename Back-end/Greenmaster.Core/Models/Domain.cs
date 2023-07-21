using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster.Core.Models.Placeables;

namespace Greenmaster.Core.Models;

public class Domain
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DomainId { get; set; }
    public int OwnerId { get; set; }
    //public string GroundPlanImageBase64{ get; set; } TODO: add groundplan of the domain 
    public List<Placeable> Placeables { get; set; }
    public List<Area> Areas { get; set; }
}