namespace Greenmaster.Contracts.Dto;

public class SpecieDto
{
    public int Id { get; set; }
    #region Naming
    public string Genus { get; set; }
    public string Species { get; set; }
    public string? Cultivar { get; set; }
    public string CommonNames { get; set; }
    #endregion
    public string Description { get; set; }
    public int PlantTypeId { get; set; }
    public virtual string PlantType { get; set; }
    public bool IsPoisonous { get; set; }
    public string Cycle { get; set; }
    public string Shape { get; set; }

    #region Requirements
    public string Sunlight { get; set; }
    public string Water { get; set; }
    public string Climate { get; set; }
    public int MinimalTemperature { get; set; }
    #endregion

    //MaxDimensions
    public double MaxHeight { get; set; }
    public double MaxWidth { get; set; }
    
    //TODO: Add symbiosis for specie
   
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