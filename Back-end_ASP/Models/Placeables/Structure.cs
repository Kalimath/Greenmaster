using Greenmaster_ASP.Models.Measurements;

namespace Greenmaster_ASP.Models.Placeables;

public class Structure : Placeable
{
    public Structure()
    {
        
    }
    public Structure(int typeId, Dimensions dimensions, Point? location = null): base(typeId, dimensions, location)
    {
    }
}