namespace eu.mbdevelopment.greenmaster.Contracts.Botanical.Dto;

public class SpecieDto
{
    public Guid Id { get; set; }
    #region Naming
    public string Genus { get; set; }
    public string Species { get; set; }
    public string? Cultivar { get; set; }
    //public string ScientificName => $"{Genus} {Species}" + (string.IsNullOrEmpty(Cultivar) ? "" : $" '{Cultivar}'");
    public string[]? CommonNames { get; set; }
    #endregion
    public string Description { get; set; }
}