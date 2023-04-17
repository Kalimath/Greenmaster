namespace eu.greenmaster.Repository.Services.Placeables;

public interface IPlaceableService<T> : IContextService<T, Guid> where T : Models.Placeables.Placeable
{
}