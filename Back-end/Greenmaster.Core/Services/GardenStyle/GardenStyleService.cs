// ReSharper disable MethodNameNotMeaningful

using Greenmaster.Core.Database;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster.Core.Services.GardenStyle;

public class GardenStyleService : IGardenStyleService
{
    private readonly ArboretumContext _context;

    public GardenStyleService(ArboretumContext context)
    {
        _context = context;
    }

    public async Task Add(Models.Design.GardenStyle newObject)
    {
        _context.GardenStyles.Add(newObject);
        await _context.SaveChangesAsync();
    }

    public async Task<Models.Design.GardenStyle> GetById(int id)
    {
        return (await GetAll()).FirstOrDefault(m => m.Id == id)
               ?? throw new ArgumentException($"No garden-style found with {nameof(id)}={id}");
    }

    public async Task<List<Models.Design.GardenStyle>> GetAll()
    {
        return (await _context.GetAllGardenStyles()).OrderBy(item => item.Id).ToList();
    }

    public async Task Update(Models.Design.GardenStyle updatedObject)
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
        return (await _context.GardenStyles.FirstOrDefaultAsync(m => m.Id == id)) != null;
    }
}