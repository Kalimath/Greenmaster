using Greenmaster.Core.Database;
using Greenmaster.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster.Core.Services.Type;

public class PlantTypeService : IObjectTypeService<PlantType>
{
    private readonly ArboretumContext _context;

    public PlantTypeService(ArboretumContext context)
    {
        _context = context;
    }

    public async Task Add(PlantType newObject)
    {
        _context.PlantTypes.Add(newObject);
        await _context.SaveChangesAsync();
    }

    public async Task<PlantType> GetById(Guid id)
    {
        return (await _context.PlantTypes.FirstOrDefaultAsync(m => m.Id == id))
               ?? throw new ArgumentException($"No PlantType found with {nameof(id)}={id}");
    }

    public async Task<List<PlantType>> GetAll()
    {
        return await Task.FromResult(_context.PlantTypes.OrderBy(item => item.Id).ToList());
    }

    public async Task Update(PlantType updatedObject)
    {
        _context.Update(updatedObject);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        _context.Remove(await GetById(id));
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsWithId(Guid id)
    {
        return (await _context.PlantTypes.FirstOrDefaultAsync(m => m.Id == id)) != null;
    }
}