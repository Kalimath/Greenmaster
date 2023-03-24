using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster_ASP.Models.Base;
using Greenmaster_ASP.Models.Static.Geographic;
using Greenmaster_ASP.Models.Static.Gradation;
using Greenmaster_ASP.Models.Static.Object.Organic;
using Greenmaster_ASP.Models.Static.PlantProperties;
using static Greenmaster_ASP.Models.Static.Object.Organic.PlantType;
#pragma warning disable CS8618

namespace Greenmaster_ASP.Models;

public class Specie: BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }

    #region Naming
    [Required] public string Genus { get; set; }
    [Required] public string Species { get; set; }
    public string? Cultivar { get; set; }
    public string ScientificName => $"{Genus} {Species}" + (string.IsNullOrEmpty(Cultivar) ? "" : $" '{Cultivar}'");
    public string CommonNames { get; set; }
    #endregion
    public string Description { get; set; }
    public string PlantType { get; set; }
    public PlantType GetPlantType => GetByName(PlantType);
    public bool IsPoisonous { get; set; }
    public Lifecycle Cycle { get; set; }
    public Shape Shape { get; set; }

    #region Requirements
    public Amount Sunlight { get; set; }
    public Amount Water { get; set; }
    public ClimateType Climate { get; set; }
    public int MinimalTemperature { get; set; }
    #endregion

    //MaxDimensions
    public double MaxHeight { get; set; }
    public double MaxWidth { get; set; }
   
    #region FlowerInfo
    public string[] BloomPeriod { get; set; }
    public string[]? FlowerColors { get; set; }
    public bool IsFragrant { get; set; }
    public bool AttractsPollinators { get; set; }
    #endregion
    
    #region Media
    public string Image { get; set; }

    #endregion
}