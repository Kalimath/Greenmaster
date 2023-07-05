using Greenmaster.Core.Models.Measurements;

namespace Greenmaster.Core.Models.Placeables;

public class Structure : Placeable
{
    public Structure()
    {
        
    }
    public Structure(Guid id, string name, Guid typeId, Dimensions dimensions, Rendering rendering, DateTime? created, DateTime? modified, Point? location = null): base(id, name, typeId, dimensions, rendering, created, modified, location)
    {
    }
}