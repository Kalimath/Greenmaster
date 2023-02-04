
using Greenmaster_ASP.Models.Measurements;

namespace Greenmaster_ASP.Models;

public abstract class Placeable
{
    public int? LocationId { get; set; }
    public Location? Position { get; set; }
    public int DimensionsId { get; set; }
    public Dimensions DesiredDimensions { get; set; }
}