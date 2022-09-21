using be.Greenmaster.Models.StaticData.PlantProperties;

namespace be.Greenmaster.Models.Arboretum;

public class PlantProperties
{
    public bool Hedgeable { get; }
    public Lifecycle Cycle { get; }
    

    public PlantProperties(bool hedgeable, Lifecycle cycle)
    {
        Hedgeable = hedgeable;
        Cycle = cycle;

    }
}