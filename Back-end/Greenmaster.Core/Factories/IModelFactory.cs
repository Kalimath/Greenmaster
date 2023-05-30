using Greenmaster.Core.Models;
using Greenmaster.Core.Models.ViewModels;

namespace Greenmaster.Core.Factories;

public interface IModelFactory
{
    public Task<Specie> Create(SpecieViewModel specieViewModel);

    public SpecieViewModel ToViewModel(Specie specie);
}