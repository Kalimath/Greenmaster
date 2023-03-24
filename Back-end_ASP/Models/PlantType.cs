using Greenmaster_ASP.Models.Static.Gradation;

namespace Greenmaster_ASP.Models;

public class PlantType : ObjectType
{
    public Permeability Canopy { get; set; }
    public bool AllowAsUndergrowth { get; set; }

    public PlantType()
    {
    }

    public PlantType(string name, bool allowAsUndergrowth, string description) : base(name, description)
    {
        AllowAsUndergrowth = allowAsUndergrowth;
    }

    public PlantType(int id, string name, bool allowAsUndergrowth, string description) : base(id, name, description)
    {
        AllowAsUndergrowth = allowAsUndergrowth;
    }
}