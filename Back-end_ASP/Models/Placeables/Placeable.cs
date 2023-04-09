using Greenmaster_ASP.Models.Base;
using Greenmaster_ASP.Models.Measurements;

namespace Greenmaster_ASP.Models.Placeables;

public abstract class Placeable : BaseAuditableEntity
{
    public string Name { get; set; }
    public int? LocationId { get; set; }
    public Point? Location { get; set; }
    public int DimensionsId { get; set; }
    public Dimensions Dimensions { get; set; }
    public int TypeId { get; set; }
    public ObjectType Type { get; set; }

    // public List<Domain> Domains { get; set; }
    protected Placeable()
    {
        Created = DateTime.Now;
        Modified = DateTime.Now;
    }

    public Placeable(Guid id, string name, int typeId, Dimensions dimensions, DateTime? created, DateTime? modified, Point? location = null)
    {
        Id = id;
        Name = name;
        TypeId = typeId;
        Location = location;
        Dimensions = dimensions;
        DimensionsId = dimensions.Id;
        Created = created ?? DateTime.Now;
        Modified = modified ?? Created;
    }

    public void PlaceAt(Point location)
    {
        throw new NotImplementedException();
    }

    public bool HasLocation()
    {
        return Location != null;
    }
}