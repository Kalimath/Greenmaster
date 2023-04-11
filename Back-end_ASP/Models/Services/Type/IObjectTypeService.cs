namespace Greenmaster_ASP.Models.Services.Type;

public interface IObjectTypeService<T> : IContextService<T, int> where T : ObjectType
{
}