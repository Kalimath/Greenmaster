using System.Linq.Expressions;
using Greenmaster.Core.Database.Base;
using Greenmaster.Core.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster.Core.Database;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly ArboretumContext _dbContext;
    private readonly DbSet<T> _modelDbSets;

    public Repository(ArboretumContext dbContext)
    {
        _dbContext = dbContext;
        _modelDbSets = _dbContext.Set<T>();
    }

    public void Add(T entity)
    {
        _modelDbSets.Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _modelDbSets.AddRange(entities);
    }

    public IQueryable<T> All()
    {
        return _modelDbSets;
    }

    public void Delete(T entity)
    {
        _modelDbSets.Remove(entity);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        foreach (var entity in entities)
        {
            _modelDbSets.Remove(entity);
        }
    }

    public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return _modelDbSets.Where(predicate).FirstOrDefaultAsync()!;
    }

    public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate)
    {
        return await _modelDbSets.Where(predicate).ToListAsync();
    }

    public IQueryable<T> Query(Expression<Func<T, bool>> predicate)
    {
        return _modelDbSets.Where(predicate);
    }

    public Task<int> SaveChangesAsync()
    {
        return _dbContext.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _modelDbSets.Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
    } 
}