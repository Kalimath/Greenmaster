using Greenmaster.Core.Models;

namespace Greenmaster.Core.Services.Type;

public interface IObjectTypeService<T> : IContextService<T, Guid> where T : ObjectType
{
}