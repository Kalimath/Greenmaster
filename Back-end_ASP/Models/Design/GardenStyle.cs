using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster_ASP.Models.Static.Design;

namespace Greenmaster_ASP.Models.Design;

public class GardenStyle
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string[] Concepts { get; set; }
    public string[] Shapes { get; set; }
    public string[] Colors { get; set; }
    public bool RequiresLargeGarden { get; set; }
    
    //TODO: add media 
}