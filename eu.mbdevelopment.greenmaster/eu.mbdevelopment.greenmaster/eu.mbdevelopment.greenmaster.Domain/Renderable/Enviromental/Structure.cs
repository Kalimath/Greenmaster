using System.Drawing;
using eu.mbdevelopment.greenmaster.Domain.Geometric;
using Point = eu.mbdevelopment.greenmaster.Domain.Geometric.Point;

namespace eu.mbdevelopment.greenmaster.Domain.Renderable.Enviromental;

public class Structure : Placeable
{
    public Structure()
    {
        
    }
    public Structure(Guid id, string name, int typeId, Dimensions dimensions, Rendering rendering, DateTime? created, DateTime? modified, Point? location = null): base(id, name, typeId, dimensions, rendering, created, modified, location)
    {
    }
}