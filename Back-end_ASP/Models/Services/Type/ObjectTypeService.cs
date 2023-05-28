using Greenmaster_ASP.Database.Arboretum;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster_ASP.Models.Services.Type;

public class ObjectTypeService : IObjectTypeService<ObjectType>
{
    private readonly ArboretumContext _context;

    public ObjectTypeService(ArboretumContext context)
    {
        _context = context;
    }

    public async Task Add(ObjectType newObject)
    {
        _context.ObjectTypes.Add(newObject);
        await _context.SaveChangesAsync();
    }

    public async Task<ObjectType> GetById(int id)
    {
        return (await _context.ObjectTypes.FirstOrDefaultAsync(m => m.Id == id))
               ?? throw new ArgumentException($"No {nameof(ObjectType)} found with {nameof(id)}={id}");
    }

    public async Task<List<ObjectType>> GetAll()
    {
        return await Task.FromResult(_context.ObjectTypes.OrderBy(item => item.Id).ToList());
    }

    public async Task Update(ObjectType updatedObject)
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
        return (await _context.ObjectTypes.FirstOrDefaultAsync(m => m.Id == id)) != null;
    }
}