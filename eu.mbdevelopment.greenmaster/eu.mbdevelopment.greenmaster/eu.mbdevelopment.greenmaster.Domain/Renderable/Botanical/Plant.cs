using eu.mbdevelopment.greenmaster.Domain.Geometric;

namespace eu.mbdevelopment.greenmaster.Domain.Renderable.Botanical;

public class Plant : Placeable
{
    public int SpecieId { get; set; }
    public Specie Specie { get; set; }

    public Plant()
    {
        
    }
    public Plant(Guid id, string name, Specie specie, int typeId, Dimensions dimensions, Rendering rendering, DateTime? created,
        DateTime? modified, Point? location = null): base(id, name, typeId, dimensions, rendering, created, modified, location)
    {
        Specie = specie;
    }
}