using Greenmaster_ASP.Models.Measurements;

namespace Greenmaster_ASP.Models.Placeables;

public class Structure : Placeable
{
    public Structure()
    {
        
    }
    public Structure(StructureType type, Dimensions dimensions, Point? location = null): base(type, dimensions, location)
    {
    }
}