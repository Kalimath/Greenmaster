namespace Greenmaster_ASP.Models.Services;

public interface IObjectTypeService<T> : IContextService<T> where T : ObjectType
{
}