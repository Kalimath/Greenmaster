namespace eu.greenmaster.EFCore.Services;

public interface IPlaceableService<T> : IContextService<T, Guid> where T : Models.Placeables.Placeable
{
}