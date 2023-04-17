using eu.greenmaster.Models.Placeables;
using Microsoft.EntityFrameworkCore;

namespace eu.greenmaster.Repository.Services.Placeables;

public class StructureService : IStructureService
{
    private readonly ArboretumContext _context;

    public StructureService(ArboretumContext context)
    {
        _context = context;
    }


    public async Task Add(Structure newObject)
    {
        _context.Structures.Add(newObject);
        await _context.SaveChangesAsync();
    }
    
    public Task<Structure> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Structure> GetById(Guid id)
    {
        return (await _context.Structures.FirstOrDefaultAsync(m => m.Id.ToString() == id.ToString()))
               ?? throw new ArgumentException($"No Structure found with {nameof(id)}={id}");
    }

    public async Task<List<Structure>> GetAll()
    {
        return (List<Structure>)(await _context.GetAllStructures());
    }

    public async Task Update(Structure updatedObject)
    {
        _context.Structures.Update(updatedObject);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        _context.Structures.Remove(await GetById(id));
        await _context.SaveChangesAsync();
    }
    
    public async Task<bool> ExistsWithId(Guid id)
    {
        return (await _context.Structures.FirstOrDefaultAsync(m => m.Id.ToString() == id.ToString())) != null;
    }
}