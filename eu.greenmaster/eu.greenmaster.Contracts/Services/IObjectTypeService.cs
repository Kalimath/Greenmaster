using eu.greenmaster.Models;

namespace eu.greenmaster.Repository.Services.Type;

public interface IObjectTypeService<T> : IContextService<T, int> where T : ObjectType
{
}