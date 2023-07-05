using System.ComponentModel.DataAnnotations;
using Greenmaster.Core.Models.Base;

namespace Greenmaster.Core.Models;

public abstract class ObjectType : BaseAuditableEntity
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