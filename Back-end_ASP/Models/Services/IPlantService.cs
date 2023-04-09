using Greenmaster_ASP.Models.Placeables;

namespace Greenmaster_ASP.Models.Services;

public interface IPlantService
{
    Task<Plant> GetById(Guid id);
    Task Delete(Guid id);
}