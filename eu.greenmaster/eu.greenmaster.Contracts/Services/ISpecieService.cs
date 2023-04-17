
namespace eu.greenmaster.Repository.Services.Specie;

public interface ISpecieService : IContextService<Models.Specie, int>
{
    public Task<Models.Specie> GetByScientificName(string scientificName);
}