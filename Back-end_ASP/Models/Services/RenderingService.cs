using Greenmaster_ASP.Models.Database.Arboretum;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster_ASP.Models.Services;

public class RenderingService : IRenderingService
{
    private readonly ArboretumContext _context;
    public RenderingService(ArboretumContext context)
    {
        _context = context;
    }
    public async Task Add(Rendering newObject)
    {
        _context.Renderings.Add(newObject);
        await _context.SaveChangesAsync();
    }

    public async Task<Rendering> GetById(int id)
    {
        return (await _context.Renderings.FirstOrDefaultAsync(m => m.Id == id))
               ?? throw new ArgumentException($"No Rendering found with {nameof(id)}={id}");
    }

    public async Task<List<Rendering>> GetAll()
    {
        return await Task.FromResult(_context.Renderings.ToList());
    }

    public async Task Update(Rendering updatedObject)
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