using eu.mbdevelopment.greenmaster.Domain.Base;
using eu.mbdevelopment.greenmaster.Domain.Geometric;

namespace eu.mbdevelopment.greenmaster.Domain.Areal;

public class Area : BaseEntity
{
    public string Name { get; set; }
    public bool IsOccupied { get; set; }
    public List<Point> EdgePoints { get; set; }

    public int DomainId { get; set; }
    public Domain Domain { get; set; }
}