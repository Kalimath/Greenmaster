using Greenmaster_ASP.Database.Arboretum;
using Microsoft.EntityFrameworkCore;
using ArgumentException = System.ArgumentException;

namespace Greenmaster_ASP.Models.Services.MaterialType;

public class MaterialTypeService : IMaterialTypeService
{
    private readonly ArboretumContext _context;
    
    public MaterialTypeService(ArboretumContext context)
    {
        _context = context;
    }
    
    public async Task Add(Design.MaterialType newObject)
    {
        _context.MaterialTypes.Add(newObject);
        await _context.SaveChangesAsync();
    }

    public async Task<Design.MaterialType> GetById(int id)
    {
        return (await GetAll()).FirstOrDefault(m => m.Id == id)
               ?? throw new ArgumentException($"No material-type found with {nameof(id)}={id}");
    }

    public async Task<List<Design.MaterialType>> GetAll()
    {
        return await Task.FromResult(_context.MaterialTypes.OrderBy(item => item.Id).ToList());
    }

    public async Task Update(Design.MaterialType updatedObject)
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