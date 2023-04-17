
namespace eu.greenmaster.EFCore.Services;

public interface ISpecieService : IContextService<Models.Specie, int>
{
    public Task<Models.Specie> GetByScientificName(string scientificName);
}