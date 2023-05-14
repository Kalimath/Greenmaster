using System.ComponentModel;
using eu.mbdevelopment.greenmaster.Enum.Gradation;

namespace eu.mbdevelopment.greenmaster.Domain.Renderable.Botanical;

public class PlantType : ObjectType
{
    public Permeability Canopy { get; set; }
    
    [DisplayName("Allow to grow underneath canopy of other plants")]
    public bool AllowAsUndergrowth { get; set; }

    public PlantType()
    {
    }

    public PlantType(string name, bool allowAsUndergrowth, Permeability canopy, string description) : base(name, description)
    {
        AllowAsUndergrowth = allowAsUndergrowth;
        Canopy = canopy;
    }

    public PlantType(Guid id, string name, bool allowAsUndergrowth, Permeability canopy, string description) : base(id, name, description)
    {
        AllowAsUndergrowth = allowAsUndergrowth;
        Canopy = canopy;
    }
}