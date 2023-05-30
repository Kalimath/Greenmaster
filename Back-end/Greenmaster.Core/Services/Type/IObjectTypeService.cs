using Greenmaster.Core.Models;

namespace Greenmaster.Core.Services.Type;

public interface IObjectTypeService<T> : IContextService<T, int> where T : ObjectType
{
}