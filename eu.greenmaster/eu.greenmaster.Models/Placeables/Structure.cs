using eu.greenmaster.Models.Measurements;

namespace eu.greenmaster.Models.Placeables;

public class Structure : Placeable
{
    public Structure()
    {
        
    }
    public Structure(Guid id, string name, int typeId, Dimensions dimensions, Rendering rendering, DateTime? created, DateTime? modified, Point? location = null): base(id, name, typeId, dimensions, rendering, created, modified, location)
    {
    }
}