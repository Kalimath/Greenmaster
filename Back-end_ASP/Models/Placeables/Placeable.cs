using Greenmaster_ASP.Models.Base;
using Greenmaster_ASP.Models.Measurements;

namespace Greenmaster_ASP.Models.Placeables;

public abstract class Placeable : BaseAuditableEntity
{
    public string Name { get; set; }
    public Point? Location { get; set; }
    public int DimensionsId { get; set; }
    public virtual Dimensions Dimensions { get; set; }
    public ObjectType Type { get; set; }

    // public List<Domain> Domains { get; set; }
    protected Placeable()
    {
    }

    public Placeable(ObjectType type, Dimensions dimensions, Point? location = null)
    {
        Type = type;
        Location = location;
        Dimensions = dimensions;
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