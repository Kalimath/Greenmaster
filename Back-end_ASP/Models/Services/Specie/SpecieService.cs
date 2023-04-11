using Greenmaster_ASP.Models.Database.Arboretum;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster_ASP.Models.Services.Specie;

public class SpecieService : ISpecieService
{
    private readonly ArboretumContext _context;

    public SpecieService(ArboretumContext context)
    {
        _context = context;
    }

    public Task<List<Models.Specie>> GetAll()
    {
        return Task.FromResult(_context.GetAllSpecies().ToList());
    }
    
    public async Task<Models.Specie> GetByScientificName(string scientificName)
    {
        return (await GetAll()).FirstOrDefault(specie => specie.ScientificName == scientificName) 
               ?? throw new ArgumentException($"No Specie found with scientific name={scientificName}");
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