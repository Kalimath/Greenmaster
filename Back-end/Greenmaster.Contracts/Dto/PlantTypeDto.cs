namespace Greenmaster.Contracts.Dto;

public class PlantTypeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Canopy { get; set; }
    public bool AllowAsUndergrowth { get; set; }
}