using Greenmaster.Core.Database;
using Greenmaster.Core.Models.Placeables;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster.Core.Services.Placeables;

public class PlantService : IPlantService
{
    private readonly ArboretumContext _context;

    public PlantService(ArboretumContext context)
    {
        _context = context;
    }


    public async Task Add(Plant newObject)
    {
        _context.Plants.Add(newObject);
        await _context.SaveChangesAsync();
    }

    public async Task<Plant> GetById(Guid id)
    {
        return (await _context.Plants.FirstOrDefaultAsync(m => m.Id.ToString() == id.ToString()))
               ?? throw new ArgumentException($"No Plant found with {nameof(id)}={id}");
    }

    public async Task<List<Plant>> GetAll()
    {
        return ((List<Plant>)await _context.GetAllPlants()).OrderBy(item => item.Id).ToList();
    }

    public async Task Update(Plant updatedObject)
    {
        _context.Plants.Update(updatedObject);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        _context.Plants.Remove(await GetById(id));
        await _context.SaveChangesAsync();
    }
    
    public async Task<bool> ExistsWithId(Guid id)
    {
        return (await _context.Plants.FirstOrDefaultAsync(m => m.Id.ToString() == id.ToString())) != null;
    }
}