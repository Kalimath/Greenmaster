using System.Linq.Expressions;
using Greenmaster.Models.Arboretum.Plants;
using Greenmaster.Repo.Base;

namespace Greenmaster.Repo.Database.JsonData;

public class SpecieJsonRepository:IRepository<Specie>
{
    public async Task<Specie> GetAsync(Expression<Func<Specie, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Specie>> GetListAsync(Expression<Func<Specie, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Specie> Query(Expression<Func<Specie, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Specie> All()
    {
        throw new NotImplementedException();
    }

    public void Add(Specie entity)
    {
        throw new NotImplementedException();
    }

    public void AddRange(IEnumerable<Specie> entities)
    {
        throw new NotImplementedException();
    }

    public void Update(Specie entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Specie entity)
    {
        throw new NotImplementedException();
    }

    public void DeleteRange(IEnumerable<Specie> entities)
    {
        throw new NotImplementedException();
    }

    public async Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}