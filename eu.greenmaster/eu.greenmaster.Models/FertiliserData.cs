using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eu.greenmaster.Models;

public class FertiliserData
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int FertiliserDataId { get; set; }

    public bool RequiresLime { get; set; }
    public int NitrogenLevel { get; set; }
    public int PhosphorLevel { get; set; }
    public int PotassiumLevel { get; set; }
    
}