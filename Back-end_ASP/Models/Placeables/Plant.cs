using Greenmaster_ASP.Models.Measurements;

namespace Greenmaster_ASP.Models.Placeables;

public class Plant : Placeable
{
    public int SpecieId { get; set; }
    public Specie Specie { get; set; }

    public Plant()
    {
        
    }
    public Plant(Guid id, string name, Specie specie, int typeId, Dimensions dimensions, DateTime? created,
        DateTime? modified, Point? location = null): base(id, name, typeId, dimensions, created, modified, location)
    {
        Specie = specie;
        SpecieId = specie.Id;
    }
}