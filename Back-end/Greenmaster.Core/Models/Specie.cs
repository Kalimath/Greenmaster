using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Greenmaster.Core.Models.Placeables;
using StaticData.Coloring;
using StaticData.Geographic;
using StaticData.Gradation;
using StaticData.Object.Organic;
using StaticData.PlantProperties;
using StaticData.Taxonomy;
using StaticData.Time.Durations;

#pragma warning disable CS8618

namespace Greenmaster.Core.Models;

public class Specie : IObjectIdentity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }

    #region Naming
    [Required] public PlantGenus Genus { get; set; }
    public string Species { get; set; }
    public string? Cultivar { get; set; }
    public string ScientificName => $"{Genus} {Species}" + (string.IsNullOrEmpty(Cultivar) ? "" : $" '{Cultivar}'");
    public string CommonNames { get; set; }
    #endregion
    public string Description { get; set; }
    public int PlantTypeId { get; set; }
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
    //TODO: determine if sections can be extracted to separate classes
    //MaxDimensions
    public double MaxHeight { get; set; }
    public double MaxWidth { get; set; }
    
    //Symbiosis for specie
    [AllowNull]
    public PlantGenus[] MutualisticGenera { get; set; }

    #region FlowerInfo
    public Month[] BloomPeriod { get; set; }
    public Color[] FlowerColors { get; set; }
    public bool IsFragrant { get; set; }
    
    //Affects allergies and attraction of butterflies and bees TODO: correct name ->  anemophilous
    public bool PollinatingFlowers { get; set; }
    #endregion
    
    #region Media
    public string Image { get; set; }

    #endregion
    
    #region EF Relations
    public virtual Collection<Plant> Plants { get; set; } = new();
    #endregion
}