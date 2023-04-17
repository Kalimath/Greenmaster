namespace eu.greenmaster.Contracts.Dtos.Species;

public class SpecieDto
{
    public int Id { get; set; }
    public string Genus { get; set; }
    public string Species { get; set; }
    public string? Cultivar { get; set; }
    public string ScientificName { get; set; }
    public string CommonNames { get; set; }
    public string Description { get; set; }
    public int PlantTypeId { get; set; }
    public bool IsPoisonous { get; set; }
    public string Cycle { get; set; }
    public string Shape { get; set; }
    
    public string Sunlight { get; set; }
    public string Water { get; set; }
    public string Climate { get; set; }
    public int MinimalTemperature { get; set; }
    
    public double MaxHeight { get; set; }
    public double MaxWidth { get; set; }

    public string[] BloomPeriod { get; set; }
    public string[]? FlowerColors { get; set; }
    public bool IsFragrant { get; set; }
    public bool AttractsPollinators { get; set; }
    
    public string Image { get; set; }
}