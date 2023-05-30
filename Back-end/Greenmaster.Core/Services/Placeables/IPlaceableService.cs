namespace Greenmaster.Core.Services.Placeables;

public interface IPlaceableService<T> : IContextService<T, Guid> where T : Models.Placeables.Placeable
{
}