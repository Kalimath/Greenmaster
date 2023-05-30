using Greenmaster.Core.Helpers;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.Placeables;
using Greenmaster.Core.Models.ViewModels;

namespace Greenmaster.Core.Factories;

public static class PlaceableFactory
{
    public static async Task<Placeable> Create(PlaceableViewModel viewModel)
    {
        ValidateViewModel(viewModel);

        var timeModified = (DateTime)(viewModel.Modified ?? viewModel.Created!);
        Rendering renderingFromViewModel = null!;
        if (viewModel.Rendering != null)
        {
            renderingFromViewModel = await RenderingFactory.Create(viewModel.Rendering);
        }

        if (viewModel.Specie != null)
        {
            if (viewModel.Type is not PlantType)
                throw new ArgumentException("If Placeable has Specie, Type must be a PlantType",
                    nameof(viewModel.Type));

            var plant = new Plant
            {
                Id = viewModel.Id,
                Created = (DateTime)viewModel.Created!,
                Modified = timeModified,
                Name = viewModel.Name,
                Location = viewModel.Location,
                DimensionsId = viewModel.DimensionsId,
                Dimensions = viewModel.Dimensions!,
                TypeId = (int)viewModel.TypeId!,
                RenderingId = ((int)(renderingFromViewModel?.Id ?? viewModel.RenderingId)!),
                Rendering = renderingFromViewModel!,
                Specie = viewModel.Specie
            };
            return plant;
        }

        var structure = new Structure
        {
            Id = viewModel.Id,
            Created = (DateTime)viewModel.Created!,
            Modified = timeModified,
            Name = viewModel.Name,
            Location = viewModel.Location,
            DimensionsId = viewModel.DimensionsId,
            Dimensions = viewModel.Dimensions!,
            TypeId = (int)viewModel.TypeId!,
            RenderingId = ((int)(renderingFromViewModel?.Id ?? viewModel.RenderingId)!),
            Rendering = renderingFromViewModel!
        };
        return structure;
    }

    public static PlaceableViewModel ToViewModel(Placeable placeable)
    {
        ValidatePlaceable(placeable);
        var renderingViewModel = RenderingFactory.ToViewModel(placeable.Rendering);

        return new PlaceableViewModel
        {
            Id = placeable.Id,
            Created = placeable.Created,
            Modified = placeable.Modified,
            Name = placeable.Name,
            LocationId = (int)(placeable.Location?.Id ?? placeable.LocationId!),
            Location = placeable.Location,
            DimensionsId = placeable.DimensionsId,
            Dimensions = placeable.Dimensions,
            TypeId = placeable.TypeId,
            Type = placeable.Type,
            RenderingId = ((int)(renderingViewModel?.Id ?? placeable.RenderingId)!),
            Rendering = renderingViewModel!,
            Specie = placeable is Plant plant ? plant.Specie : null
        };
    }

    private static void ValidateViewModel(PlaceableViewModel viewModel)
    {
        if (!StringValidator.IsValidString(viewModel.Name))
            throw new ArgumentException("string was invalid", nameof(viewModel.Name));
        if (viewModel.Created == default)
            throw new ArgumentException("DateTime was invalid", nameof(viewModel.Created));
        if (viewModel.Modified != default && viewModel.Modified < viewModel.Created)
            throw new ArgumentException("Modified before created", nameof(viewModel.Modified));

        ValidateDimensions(viewModel);
        ValidateLocation(viewModel);
        ValidateType(viewModel);
        ValidateRendering(viewModel);
    }

    #region ViewModelValidators

    private static void ValidateRendering(PlaceableViewModel viewModel)
    {
        if (viewModel.RenderingId <= 0)
        {
            if (viewModel.Rendering == default)
            {
                throw new ArgumentNullException(nameof(viewModel.Rendering),
                    $"Placeable must have a {nameof(viewModel.RenderingId)} and/or a {nameof(viewModel.Rendering)}, currently both are default/null");
            }

            if (viewModel.RenderingId != viewModel.Rendering.Id)
                throw new ArgumentOutOfRangeException(nameof(viewModel.RenderingId),
                    message: $"{nameof(viewModel.RenderingId)} does not match {nameof(viewModel.Rendering)}.Id");
        }
    }

    private static void ValidateType(PlaceableViewModel viewModel)
    {
        if (viewModel.TypeId <= 0)
        {
            if (viewModel.Type == default)
            {
                throw new ArgumentNullException(nameof(viewModel.Type),
                    $"Placeable must have a {nameof(viewModel.TypeId)} and/or a {nameof(viewModel.Type)}, currently both are default/null");
            }

            if (viewModel.TypeId != viewModel.Type.Id)
                throw new ArgumentOutOfRangeException(nameof(viewModel.TypeId),
                    message: $"{nameof(viewModel.TypeId)} does not match Dimensions.Id");
        }
    }

    private static void ValidateLocation(PlaceableViewModel viewModel)
    {
        if (viewModel.LocationId <= 0)
        {
            if (viewModel.Location == default)
            {
                throw new ArgumentNullException(nameof(viewModel.Location),
                    $"Placeable must have a {nameof(viewModel.LocationId)} and/or a {nameof(viewModel.Location)}, currently both are default/null");
            }

            if (viewModel.LocationId != viewModel.Location?.Id)
                throw new ArgumentOutOfRangeException(nameof(viewModel.LocationId),
                    message: $"{nameof(viewModel.LocationId)} does not match {nameof(viewModel.Location)}.Id");
        }
    }

    private static void ValidateDimensions(PlaceableViewModel viewModel)
    {
        if (viewModel.DimensionsId <= 0)
        {
            if (viewModel.Dimensions == default)
            {
                throw new ArgumentNullException(nameof(viewModel.Dimensions),
                    $"Placeable must have a {nameof(viewModel.DimensionsId)} and/or a {nameof(viewModel.Dimensions)}, currently both are default/null");
            }

            if (viewModel.DimensionsId != viewModel.Dimensions?.Id)
                throw new ArgumentOutOfRangeException(nameof(viewModel.DimensionsId),
                    message: $"{nameof(viewModel.DimensionsId)} does not match {nameof(viewModel.Dimensions)}.Id");
        }
    }

    #endregion

    private static void ValidatePlaceable(Placeable placeable)
    {
        ValidatePlaceableDimensions(placeable);
        ValidatePlaceableAuditData(placeable);

        if (!StringValidator.IsValidString(placeable.Name))
            throw new ArgumentException(nameof(placeable.Name));

        ValidatePlant(placeable);
        ValidatePlaceableLocation(placeable);
        ValidatePlaceableRendering(placeable);
    }

    #region PlaceableValidators

    private static void ValidatePlaceableDimensions(Placeable placeable)
    {
        if (placeable.Dimensions == null)
        {
            if (placeable.DimensionsId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(placeable.DimensionsId));
            }

            throw new ArgumentNullException(nameof(placeable.Dimensions));
        }
        if (placeable.DimensionsId != placeable.Dimensions.Id)
            throw new ArgumentException($"{nameof(placeable.DimensionsId)} does not match {nameof(placeable.Dimensions)}.Id");
    }

    private static void ValidatePlaceableAuditData(Placeable placeable)
    {
        if (placeable.Created == default)
            throw new ArgumentException(nameof(placeable.Created));

        if (placeable.Modified != default && placeable.Modified < placeable.Created)
            throw new ArgumentOutOfRangeException(nameof(placeable.Modified), "Modified before created");
    }

    private static void ValidatePlant(Placeable placeable)
    {
        if (placeable.Type == null)
            throw new ArgumentNullException(nameof(Plant.Specie), "Placeable with PlantType = null");

        if (placeable.Type is PlantType && (placeable as Plant)?.Specie == null)
            throw new ArgumentNullException(nameof(Plant.Specie), "Placeable with PlantType has specie = null");
        
        if (placeable.TypeId != placeable.Type.Id)
            throw new ArgumentException($"{nameof(placeable.TypeId)} does not match {nameof(placeable.Type)}.Id");
    }

    private static void ValidatePlaceableLocation(Placeable placeable)
    {
        if (placeable.Location != null)
        {
            if (placeable.LocationId <= 0)
                throw new ArgumentOutOfRangeException(nameof(placeable.LocationId));

            if (placeable.LocationId != placeable.Location.Id)
                throw new ArgumentException($"{nameof(placeable.LocationId)} does not match {nameof(placeable.Location)}.Id");
        }
    }

    private static void ValidatePlaceableRendering(Placeable placeable)
    {
        if (placeable.RenderingId <= 0)
            throw new ArgumentOutOfRangeException(nameof(placeable.RenderingId));
        if (placeable.Rendering == null)
            throw new ArgumentNullException(nameof(placeable.Rendering), "Placeable with rendering = null");
        if (placeable.RenderingId != placeable.Rendering.Id)
            throw new ArgumentException($"{nameof(placeable.RenderingId)} does not match {nameof(placeable.Rendering)}.Id");
    }

    #endregion
}