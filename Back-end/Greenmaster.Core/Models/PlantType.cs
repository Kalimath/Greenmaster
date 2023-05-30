using System.ComponentModel;
using StaticData.Gradation;

namespace Greenmaster.Core.Models;

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

    public PlantType(int id, string name, bool allowAsUndergrowth, Permeability canopy, string description) : base(id, name, description)
    {
        AllowAsUndergrowth = allowAsUndergrowth;
        Canopy = canopy;
    }
}