using System.ComponentModel.DataAnnotations;
using eu.mbdevelopment.greenmaster.Domain.Base;

#pragma warning disable CS8618

namespace eu.mbdevelopment.greenmaster.Domain.Renderable.Botanical;

public class Specie : BaseAuditableEntity
{
    #region Naming
    [Required] public string Genus { get; set; }
    [Required] public string Species { get; set; }
    public string? Cultivar { get; set; }
    public string ScientificName => $"{Genus} {Species}" + (string.IsNullOrEmpty(Cultivar) ? "" : $" '{Cultivar}'");
    public string[]? CommonNames { get; set; }
    #endregion
    public string Description { get; set; }
    
    /*public int PlantTypeId { get; set; }
    public virtual PlantType PlantType { get; set; }
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
    public string[]? BloomPeriod { get; set; }
    public string[]? FlowerColors { get; set; }
    public bool IsFragrant { get; set; }
    public bool AttractsPollinators { get; set; }
    #endregion
    
    #region Media
    public string Image { get; set; }

    #endregion*/
}