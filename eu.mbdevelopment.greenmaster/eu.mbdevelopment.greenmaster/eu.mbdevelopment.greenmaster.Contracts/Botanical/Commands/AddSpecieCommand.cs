using System.Drawing;
using eu.mbdevelopment.greenmaster.Contracts.Base;
using eu.mbdevelopment.greenmaster.Contracts.Botanical.Dto;
using FluentValidation;

namespace eu.mbdevelopment.greenmaster.Contracts.Botanical.Commands;

public class AddSpecieCommand : CommandBase<SpecieDto>
{
    #region Naming
    public string Genus { get; set; }
    public string Species { get; set; }
    public string? Cultivar { get; set; }
    //public string ScientificName => $"{Genus} {Species}" + (string.IsNullOrEmpty(Cultivar) ? "" : $" '{Cultivar}'");
    public string[]? CommonNames { get; set; }
    #endregion
    public string Description { get; set; }
    
    /*public int PlantTypeId { get; set; }
    public string PlantType { get; set; }
    public bool IsPoisonous { get; set; } = false;
    public Lifecycle Cycle { get; set; }
    public Shape Shape { get; set; }

    #region Requirements
    public Amount Sunlight { get; set; }
    public Amount Water { get; set; }
    public ClimateType Climate { get; set; }
    public int MinimalTemperature { get; set; }
    #endregion

    #region Dimensions

    public double MaxHeight { get; set; }
    public double MaxWidth { get; set; }
    
    #endregion 
   
    #region FlowerInfo
    public string[]? BloomPeriod { get; set; }
    public Color[]? FlowerColors { get; set; }
    public bool IsFragrant { get; set; } = false;
    public bool AttractsPollinators { get; set; } = false;
    #endregion
    
    #region Media
    public string Image { get; set; }
    #endregion*/
    
    public class AddSpecieCommandValidator : AbstractValidator<AddSpecieCommand>
    {
        public AddSpecieCommandValidator()
        {
            RuleFor(specie => specie.Genus).NotEmpty();
            RuleFor(specie => specie.Species).NotEmpty();
            RuleFor(specie => specie.Description).NotEmpty();
            
            /*
            RuleFor(specie => specie.PlantTypeId).NotEmpty().When(specie => string.IsNullOrWhiteSpace(specie.PlantType));
            RuleFor(specie => specie.PlantType).NotEmpty().When(specie => specie.PlantTypeId <= 0);
            RuleFor(specie => specie.Cycle).NotEmpty().IsInEnum();
            RuleFor(specie => specie.Shape).NotEmpty().IsInEnum();
            RuleFor(specie => specie.Sunlight).NotEmpty().IsInEnum();
            RuleFor(specie => specie.Water).NotEmpty().IsInEnum();
            RuleFor(specie => specie.Climate).NotEmpty().IsInEnum();
            RuleFor(specie => specie.MinimalTemperature).NotEmpty();
            
            RuleFor(specie => specie.MaxHeight).NotEmpty().Must(d => d>0);
            RuleFor(specie => specie.MaxWidth).NotEmpty().Must(d => d>0);*/
        }
    }
}