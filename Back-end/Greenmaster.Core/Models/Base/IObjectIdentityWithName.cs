using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Greenmaster.Core.Models.Base;

public interface IObjectIdentityWithName : IObjectIdentity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }
    public string Name { get; set; }
    
}