using Greenmaster_ASP.Models.ViewModels;

namespace Greenmaster_ASP.Models.Factories;

public interface IModelFactory
{
    public Task<Specie> Create(SpecieViewModel specieViewModel);

    public SpecieViewModel ToViewModel(Specie specie);
}