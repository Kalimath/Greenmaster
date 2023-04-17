using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eu.greenmaster.Models.Base;

namespace eu.greenmaster.Models;

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