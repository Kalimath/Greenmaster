using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster_ASP.Models.Arboretum;
using Greenmaster_ASP.Models.Measurements;
using Greenmaster_ASP.Models.StaticData.Object.Organic;

namespace Greenmaster_ASP.Models;

public class Specie
{
    [ForeignKey(nameof(Plant))]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SpecieId { get; set; }

    public string ScientificName { get; set; }
    public virtual PlantRequirements Requirements { get; set; }
    public virtual FlowerData? FlowerInfo { get; set; }
    public virtual SpecieDimensions Dimensions { get; set; }
    public Lifecycle Lifecycle { get; set; }
}