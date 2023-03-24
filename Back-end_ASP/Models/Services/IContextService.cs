using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace Greenmaster_ASP.Models.Services;

public interface IContextService<T>
{
    public Task Add(T newObject);
    public Task<T> GetById(int id);
    public Task<List<T>> GetAll();
    public Task Update(T updatedObject);
    public Task Delete(int id);
    public Task<bool> ExistsWithId(int id);
}