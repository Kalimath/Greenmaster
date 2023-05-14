using System.ComponentModel.DataAnnotations.Schema;
using eu.mbdevelopment.greenmaster.Domain.Base;
using eu.mbdevelopment.greenmaster.Domain.Renderable;

namespace eu.mbdevelopment.greenmaster.Domain.Areal;

public class Domain : BaseEntity
{
    public int OwnerId { get; set; }
    public List<Placeable> Placeables { get; set; }
    public List<Area> Areas { get; set; }
}