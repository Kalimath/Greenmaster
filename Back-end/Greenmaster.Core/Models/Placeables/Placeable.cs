﻿using Greenmaster.Core.Models.Base;
using Greenmaster.Core.Models.Measurements;

namespace Greenmaster.Core.Models.Placeables;

public abstract class Placeable : BaseAuditableEntity
{
    public string Name { get; set; }
    public int? LocationId { get; set; }
    public Point? Location { get; set; }
    public int DimensionsId { get; set; }
    public Dimensions Dimensions { get; set; }
    public int TypeId { get; set; }
    public ObjectType Type { get; set; }
    public int RenderingId { get; set; }
    public Rendering Rendering { get; set; }

    // public List<Domain> Domains { get; set; }
    protected Placeable()
    {
    }

    public Placeable(Guid id, string name, int typeId, Dimensions dimensions, Rendering rendering, DateTime? created, DateTime? modified, Point? location = null)
    {
        Id = id;
        Name = name;
        TypeId = typeId;
        Location = location;
        Dimensions = dimensions;
        DimensionsId = dimensions.Id;
        Rendering = rendering;
        Created = created ?? DateTime.Now;
        Modified = modified ?? Created;
    }

    public void PlaceAt(Point location)
    {
        throw new NotImplementedException();
    }

    public bool HasLocation()
    {
        return Location != null;
    }
}