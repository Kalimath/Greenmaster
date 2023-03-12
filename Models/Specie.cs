using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster_ASP.Models.Static.Object.Organic;

namespace Greenmaster_ASP.Models;

public class Specie
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }
    [Required]
    public string Genus { get; set; }
    [Required]
    public string Species { get; set; }
    public string? Cultivar { get; set; }
    public string ScientificName => $"{Genus} {Species}" + (string.IsNullOrEmpty(Cultivar) ? "" : $" '{Cultivar}'");
    
    public string CommonNames { get; set; }
    public string Description { get; set; }
    
    [Required]
    [Column(name: "PlantType")]
    public string Type { get; set; }

    public PlantType GetPlantType => PlantType.GetByName(Type);

    [Required]
    public Lifecycle Cycle { get; set; }
    
}