using Greenmaster_ASP.Helpers;
using Greenmaster_ASP.Models.Placeables;
using Greenmaster_ASP.Models.ViewModels;

namespace Greenmaster_ASP.Models.Factories;

public static class PlaceableFactory
{
    public static Placeable Create(PlaceableViewModel viewModel)
    {
        ValidateViewModel(viewModel);

        var timeModified = (DateTime)(viewModel.Modified ?? viewModel.Created!);
        
        if (viewModel.Specie != null)
        {
            
            if (viewModel.Type is not PlantType)
                throw new ArgumentException("If Placeable has Specie, Type must be a PlantType", nameof(viewModel.Type));

            var plant = new Plant
            {
                Id = viewModel.Id,
                Created = (DateTime)viewModel.Created!,
                Modified = timeModified,
                Name = viewModel.Name,
                Location = viewModel.Location,
                DimensionsId = viewModel.DimensionsId,
                Dimensions = viewModel.Dimensions,
                TypeId = (int)viewModel.TypeId!,
                Specie = viewModel.Specie
            };
            return plant;
        }

        var structure = new Structure
        {
            Id = viewModel.Id,
            Created = (DateTime)viewModel.Created,
            Modified = timeModified,
            Name = viewModel.Name,
            Location = viewModel.Location,
            DimensionsId = viewModel.DimensionsId,
            Dimensions = viewModel.Dimensions,
            TypeId = (int)viewModel.TypeId!
        };
        return structure;
    }

    private static void ValidateViewModel(PlaceableViewModel viewModel)
    {
        if (!StringValidator.IsValidString(viewModel.Name))
            throw new ArgumentException("string was invalid", nameof(viewModel.Name));
        if (viewModel.Created == default)
            throw new ArgumentException("DateTime was invalid", nameof(viewModel.Created));
        if (viewModel.Modified != default && viewModel.Modified < viewModel.Created)
            throw new ArgumentException("Modified before created", nameof(viewModel.Modified));
        if (viewModel.Dimensions == default)
            throw new ArgumentNullException(nameof(viewModel.Dimensions));
        if (viewModel.DimensionsId > 0)
        {
            if (viewModel.Dimensions == default)
            {
                throw new ArgumentNullException(nameof(viewModel.Dimensions),
                    "Placeable must have a DimensionsId and/or Dimensions, currently both are default/null");
            }
            if (viewModel.DimensionsId != viewModel.Dimensions.Id) 
                throw new ArgumentOutOfRangeException(nameof(viewModel.DimensionsId) ,message: "DimensionsId does not match Dimensions.Id");
        }
        if (viewModel.TypeId == default && viewModel.Type == null)
            throw new ArgumentNullException(nameof(viewModel.Type),
                "Placeable must have a TypeId and/or Type, currently both are default/null");
        if (viewModel.Type == null)
            throw new ArgumentNullException(nameof(viewModel.Type));
    }

    public static PlaceableViewModel ToViewModel(Placeable placeable)
    {
        ValidatePlaceable(placeable);
        return new PlaceableViewModel
        {
            Id = placeable.Id,
            Created = placeable.Created,
            Modified = placeable.Modified,
            Name = placeable.Name,
            Location = placeable.Location,
            DimensionsId = placeable.DimensionsId,
            Dimensions = placeable.Dimensions,
            TypeId = placeable.TypeId,
            Type = placeable.Type,
            Specie = placeable is Plant plant? plant.Specie : null
        };
    }

    private static void ValidatePlaceable(Placeable placeable)
    {
        if (placeable.Dimensions == null)
        {
            if (placeable.DimensionsId <= 0)
            {
                throw new ArgumentNullException(nameof(placeable.DimensionsId));
            }
            throw new ArgumentNullException(nameof(placeable.Dimensions));
        }
        if (placeable.Created == default)
        {
            throw new ArgumentException(nameof(placeable.Created));
        }
        if (placeable.Modified != default && placeable.Modified < placeable.Created)
        {
            throw new ArgumentOutOfRangeException(nameof(placeable.Modified), "Modified before created");
        }
        if (!StringValidator.IsValidString(placeable.Name))
        {
            throw new ArgumentException(nameof(placeable.Name));
        }

        if (placeable.Type  == null) throw new ArgumentNullException(nameof(Plant.Specie), "Placeable with PlantType has specie = null");
        
        if (placeable.Type is PlantType && (placeable as Plant)?.Specie == null)
        {
            throw new ArgumentNullException(nameof(Plant.Specie), "Placeable with PlantType has specie = null");
        }
        
    }
}