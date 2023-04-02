using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster_ASP.Models.Base;

namespace Greenmaster_ASP.Models;

public abstract class ObjectType : IObjectIdentityWithName
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }
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

    public ObjectType(int id, string name, string? description): this(name, description)
    {
        Id = id;
    }

}