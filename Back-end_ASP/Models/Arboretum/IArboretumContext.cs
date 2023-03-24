using Microsoft.EntityFrameworkCore;

namespace Greenmaster_ASP.Models.Arboretum;

public interface IArboretumContext
{
    DbSet<Specie> Species { get; set; }
    IEnumerable<Specie> GetAllSpecies();
}