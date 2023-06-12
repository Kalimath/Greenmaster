using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StaticData.Measuring;

namespace Greenmaster.Core.Models.Design;

public class GardenStyle
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string[] Concepts { get; set; }
    public string[] Shapes { get; set; }
    public string[] Colors { get; set; }
    [DisplayName(displayName: "Large garden only")]
    public bool RequiresLargeGarden { get; set; }
    public bool AllSeasonInterest { get; set; }
    public bool DivideIntoRooms { get; set; }
    
    public Size PathSize { get; set; }
    
    public virtual ICollection<MaterialType>? Materials { get; set; } = new HashSet<MaterialType>();
    public virtual ICollection<PlantType>? PlantTypes { get; set; } = new HashSet<PlantType>();

    //TODO: add media 
}