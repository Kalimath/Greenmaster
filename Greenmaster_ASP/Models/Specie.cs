using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster_ASP.Models.Measurements;
using Greenmaster_ASP.Models.StaticData.Object.Organic;

namespace Greenmaster_ASP.Models;

public class Specie
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SpecieId { get; set; }

    public string ScientificName { get; set; }

    public int PlantRequirementsId { get; set; }
    public PlantRequirements Requirements { get; set; }
    
    public int? FlowerDataId { get; set; }
    public FlowerData? FlowerInfo { get; set; }
    
    
    public int MaxDimensionsId { get; set; }
    public Dimensions MaxDimensions { get; set; } 
    
    public Lifecycle Lifecycle { get; set; }

    public List<Plant> Plants { get; set; }
    
}