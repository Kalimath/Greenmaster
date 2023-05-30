using Greenmaster.Core.Database;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster.Core.Services.Rendering;

public class RenderingService : IRenderingService
{
    private readonly ArboretumContext _context;
    public RenderingService(ArboretumContext context)
    {
        _context = context;
    }
    public async Task Add(Models.Rendering newObject)
    {
        _context.Renderings.Add(newObject);
        await _context.SaveChangesAsync();
    }

    public async Task<Models.Rendering> GetById(int id)
    {
        return (await _context.Renderings.FirstOrDefaultAsync(m => m.Id == id))
               ?? throw new ArgumentException($"No Rendering found with {nameof(id)}={id}");
    }

    public async Task<List<Models.Rendering>> GetAll()
    {
        return await Task.FromResult(_context.Renderings.OrderBy(item => item.Id).ToList());
    }

    public async Task Update(Models.Rendering updatedObject)
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
        return (await _context.Renderings.FirstOrDefaultAsync(m => m.Id == id)) != null;
    }
}