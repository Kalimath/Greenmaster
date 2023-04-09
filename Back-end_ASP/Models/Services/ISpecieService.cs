
namespace Greenmaster_ASP.Models.Services;

public interface ISpecieService : IContextService<Specie, int>
{
    public Task<Specie> GetByScientificName(string scientificName);
}