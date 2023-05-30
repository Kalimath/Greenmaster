using Greenmaster.Core.Models.Base;

namespace Greenmaster.Core.Models;

public class Area : BaseEntity
{
    public string Name { get; set; }
    public bool IsOccupied { get; set; }
    public List<Point> EdgePoints { get; set; }

    public int DomainId { get; set; }
    public Domain Domain { get; set; }
}