using eu.greenmaster.Contracts.Dtos.Species;
using FluentValidation;

namespace eu.greenmaster.Contracts.Commands.Specie;

public class AddSpecieCommand : CommandBase<SpecieDto>
{
    public int Id { get; set; }
    public string Genus { get; set; }
    public string Species { get; set; }
    public string? Cultivar { get; set; }
    public string ScientificName => $"{Genus} {Species}" + (string.IsNullOrEmpty(Cultivar) ? "" : $" '{Cultivar}'");
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


public class AddSpecieCommandValidator : AbstractValidator<AddSpecieCommand>
{
    public AddSpecieCommandValidator()
    {
        RuleFor(c => c.Genus).NotEmpty();
        RuleFor(c => c.Species).NotEmpty();
        RuleFor(c => c.Climate).NotEmpty().IsInEnum();
        RuleFor(c => c.Cycle).NotEmpty().IsInEnum();
        RuleFor(c => c.Shape).NotEmpty().IsInEnum();
        RuleFor(c => c.Sunlight).NotEmpty().IsInEnum();
        RuleFor(c => c.Water).NotEmpty().IsInEnum();
        RuleFor(c => c.MaxHeight).NotEmpty().GreaterThan(0);
        RuleFor(c => c.MaxWidth).NotEmpty().GreaterThan(0);
        RuleFor(c => c.MinimalTemperature).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.BloomPeriod);
    }
}