using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster_ASP.Models.Measurements;

namespace Greenmaster_ASP.Models.Placeables;

[Table("Plants")]
public class Plant : Placeable
{
    public Specie Specie { get; set; }

    public Plant()
    {
        
    }
    public Plant(Specie specie, int typeId, Dimensions dimensions, Point? location = null): base(typeId, dimensions, location)
    {
        Specie = specie;
    }

}