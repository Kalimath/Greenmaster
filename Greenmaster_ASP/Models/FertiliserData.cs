using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster_ASP.Models.Arboretum;

namespace Greenmaster_ASP.Models;

public class FertiliserData
{
    [ForeignKey(nameof(PlantRequirements))]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int FertiliserDataId { get; set; }

    public bool RequiresLime { get; set; }
    public int NitrogenLevel { get; set; }
    public int PhosphorLevel { get; set; }
    public int PotassiumLevel { get; set; }
}