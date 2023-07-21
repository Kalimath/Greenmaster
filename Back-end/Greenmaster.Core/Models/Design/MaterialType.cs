using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Greenmaster.Core.Models.Design;

public class MaterialType
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }
    public string Name { get; set; }
    
    [DataType(DataType.MultilineText)]
    public string Description { get; set; }
    public virtual ICollection<GardenStyle> GardenStyles { get; set; } = new HashSet<GardenStyle>();
}