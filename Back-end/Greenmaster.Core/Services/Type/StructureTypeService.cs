using Greenmaster.Core.Database;
using Greenmaster.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster.Core.Services.Type;

public class StructureTypeService : IObjectTypeService<StructureType>
{
    private readonly ArboretumContext _context;

    public StructureTypeService(ArboretumContext context)
    {
        _context = context;
    }

    public async Task Add(StructureType newObject)
    {
        _context.StructureTypes.Add(newObject);
        await _context.SaveChangesAsync();
    }

    public async Task<StructureType> GetById(int id)
    {
        return (await _context.StructureTypes.FirstOrDefaultAsync(m => m.Id == id))
               ?? throw new ArgumentException($"No Rendering found with {nameof(id)}={id}");
    }

    public async Task<List<StructureType>> GetAll()
    {
        return await Task.FromResult(_context.StructureTypes.OrderBy(item => item.Id).ToList());
    }

    public async Task Update(StructureType updatedObject)
    {
        _context.Update(updatedObject);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        _context.Remove(await GetById(id));
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsWithId(int id)
    {
        return (await _context.StructureTypes.FirstOrDefaultAsync(m => m.Id == id)) != null;
    }
}