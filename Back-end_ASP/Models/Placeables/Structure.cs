using Greenmaster_ASP.Models.Measurements;

namespace Greenmaster_ASP.Models.Placeables;

public class Structure : Placeable
{
    public Structure()
    {
        
    }
    public Structure(Guid id, string name, int typeId, Dimensions dimensions, Rendering rendering, DateTime? created, DateTime? modified, Point? location = null): base(id, name, typeId, dimensions, rendering, created, modified, location)
    {
    }
}