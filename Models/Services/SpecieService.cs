using Greenmaster_ASP.Models.Arboretum;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster_ASP.Models.Services;

public class SpecieService : ISpecieService
{
    private readonly ArboretumContext _context;

    public SpecieService(ArboretumContext context)
    {
        _context = context;
    }

    public Task<List<Specie>> GetSpecies()
    {
        return Task.FromResult(_context.GetAllSpecies().ToList());
    }
    

    public async Task<Specie> GetSpecieByScientificName(string scientificName)
    {
        return (await GetSpecies()).FirstOrDefault(specie => specie.ScientificName == scientificName) 
               ?? throw new ArgumentException($"No Specie found with scientific name={scientificName}");
    }

    public async Task<Specie> GetSpecieById(int id)
    {
        return (await _context.Species.FirstOrDefaultAsync(m => m.Id == id))
                ?? throw new ArgumentException($"No Specie found with {nameof(id)}={id}");
    }

    public async Task AddSpecie(Specie specie)
    {
        _context.Species.Add(specie);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSpecie(Specie specie)
    {
        _context.Update(specie);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSpecieById(int id)
    {
        _context.Remove(await GetSpecieById(id));
        await _context.SaveChangesAsync();
    }

    public async Task<bool> SpecieWithIdExists(int id)
    {
        return (await _context.Species.FirstOrDefaultAsync(m => m.Id == id)) != null;
    }
}