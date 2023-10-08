
using StaticData.Taxonomy;

namespace Greenmaster.Core.Services.Specie;

public interface ISpecieService : IContextService<Models.Specie, int>
{
    public Task<List<Models.Specie>> GetAllByGenus(PlantGenus genus);
}