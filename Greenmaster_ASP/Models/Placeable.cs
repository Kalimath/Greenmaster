
using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster_ASP.Models.Measurements;

namespace Greenmaster_ASP.Models;

public abstract class Placeable
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PlaceableId { get; set; }
    
    public int? LocationId { get; set; }
    public Location? Position { get; set; }
    public int DimensionsId { get; set; }
    public Dimensions DesiredDimensions { get; set; }
    
    public List<Domain> Domains { get; set; }
}