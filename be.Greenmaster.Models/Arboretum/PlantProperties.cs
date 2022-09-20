namespace be.Greenmaster.Models.Arboretum;

public class PlantProperties
{
    public bool Hedgeable { get; set; }

    public PlantProperties(bool hedgeable)
    {
        Hedgeable = hedgeable;
    }
}