using Greenmaster.Core.Database;
using Microsoft.EntityFrameworkCore;
using StaticData.Taxonomy;

namespace Greenmaster.Core.Services.Specie;

public class SpecieService : ISpecieService
{
    private readonly ArboretumContext _context;

    public SpecieService(ArboretumContext context)
    {
        _context = context;
    }

    public async Task<List<Models.Specie>> GetAll()
    {
        return await Task.FromResult(_context.GetAllSpecies().OrderBy(item => item.Id).ToList());
    }
    
    public async Task<List<Models.Specie>> GetAllByGenus(PlantGenus genus)
    {
        var all = await GetAll();
        var byGenus = new List<Models.Specie>();
        foreach (var specie in all)
        {
            if (Equals(specie.Genus, genus))
            {
                byGenus.Add(specie);
            }
        }
        return  byGenus;
    }

    public async Task<Models.Specie> GetById(int id)
    {
        return (await GetAll()).FirstOrDefault(m => m.Id == id)
                ?? throw new ArgumentException($"No Specie found with {nameof(id)}={id}");
    }

    public async Task Add(Models.Specie newObject)
    {
        _context.Species.Add(newObject);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Models.Specie updatedObject)
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
        return (await _context.Species.FirstOrDefaultAsync(m => m.Id == id)) != null;
    }
}