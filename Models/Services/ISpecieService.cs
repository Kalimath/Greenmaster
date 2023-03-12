
namespace Greenmaster_ASP.Models.Services;

public interface ISpecieService
{
    public Task<List<Specie>> GetSpecies();
    //public Task<List<Specie>> GetSpecies(Expression<Func<Specie, bool>> predicate);
    public Task<Specie> GetSpecieByScientificName(string scientificName);
    public Task<Specie> GetSpecieById(int specieId);
    public Task AddSpecie(Specie specie);
    public Task UpdateSpecie(Specie specie);
    Task DeleteSpecieById(int id);
    Task<bool> SpecieWithIdExists(int specieId);
}