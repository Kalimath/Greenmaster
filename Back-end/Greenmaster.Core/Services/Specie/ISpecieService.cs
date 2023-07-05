
namespace Greenmaster.Core.Services.Specie;

public interface ISpecieService : IContextService<Models.Specie, Guid>
{
    public Task<Models.Specie> GetByScientificName(string scientificName);
}