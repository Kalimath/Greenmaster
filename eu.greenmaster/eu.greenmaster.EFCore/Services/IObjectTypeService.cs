using eu.greenmaster.Models;

namespace eu.greenmaster.EFCore.Services;

public interface IObjectTypeService<T> : IContextService<T, int> where T : ObjectType
{
}