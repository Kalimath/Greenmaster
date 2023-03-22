
namespace Greenmaster_ASP.Models.Services;

public interface ISpecieService : IContextService<Specie>
{
    public Task<Specie> GetByScientificName(string scientificName);
}