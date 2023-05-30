using Greenmaster.Core.Database;
using Microsoft.EntityFrameworkCore;
using ArgumentException = System.ArgumentException;

namespace Greenmaster.Core.Services.MaterialType;

public class MaterialTypeService : IMaterialTypeService
{
    private readonly ArboretumContext _context;
    
    public MaterialTypeService(ArboretumContext context)
    {
        _context = context;
    }
    
    public async Task Add(Models.Design.MaterialType newObject)
    {
        _context.MaterialTypes.Add(newObject);
        await _context.SaveChangesAsync();
    }

    public async Task<Models.Design.MaterialType> GetById(int id)
    {
        return (await GetAll()).FirstOrDefault(m => m.Id == id)
               ?? throw new ArgumentException($"No material-type found with {nameof(id)}={id}");
    }

    public async Task<List<Models.Design.MaterialType>> GetAll()
    {
        return await Task.FromResult(_context.MaterialTypes.OrderBy(item => item.Id).ToList());
    }

    public async Task Update(Models.Design.MaterialType updatedObject)
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
        return (await _context.MaterialTypes.FirstOrDefaultAsync(m => m.Id == id)) != null;
    }
}