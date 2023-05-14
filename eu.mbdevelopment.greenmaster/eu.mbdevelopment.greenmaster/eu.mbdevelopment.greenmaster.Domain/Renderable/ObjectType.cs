using System.ComponentModel.DataAnnotations;
using eu.mbdevelopment.greenmaster.Domain.Base;

namespace eu.mbdevelopment.greenmaster.Domain.Renderable;

public abstract class ObjectType : BaseEntity
{
    [Required]
    [MinLength(2)]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    
    public ObjectType()
    {
    }

    public ObjectType(string name, string? description)
    {
        Name = name;
        Description = description;
    }

    public ObjectType(Guid id, string name, string? description): this(name, description)
    {
        Id = id;
    }

}