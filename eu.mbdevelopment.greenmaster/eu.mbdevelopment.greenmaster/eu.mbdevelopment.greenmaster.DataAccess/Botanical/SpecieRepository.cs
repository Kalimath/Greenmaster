using eu.mbdevelopment.greenmaster.DataAccess.Base;
using eu.mbdevelopment.greenmaster.Domain.Renderable.Botanical;
using Microsoft.EntityFrameworkCore;

namespace eu.mbdevelopment.greenmaster.DataAccess.Botanical;

public class SpecieRepository : Repository<Specie>
{
    public SpecieRepository(DbContext dbContext) : base(dbContext)
    {
    }
}