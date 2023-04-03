using Greenmaster_ASP.Helpers;
using Greenmaster_ASP.Models.Placeables;
using Greenmaster_ASP.Models.ViewModels;

namespace Greenmaster_ASP.Models.Factories;

public static class PlaceableFactory
{
    public static Placeable Create(PlaceableViewModel viewModel)
    {
        if (!StringValidator.IsValidString(viewModel.Name))
            throw new ArgumentException("string was invalid", nameof(viewModel.Name));
        if (viewModel.Created == default)
            throw new ArgumentException("DateTime was invalid", nameof(viewModel.Created));
        if (viewModel.Dimensions == default)
            throw new ArgumentNullException(nameof(viewModel.Dimensions));
        if (viewModel.DimensionsId == default && viewModel.Dimensions == default)
            throw new ArgumentNullException(nameof(viewModel.Dimensions),"Placeable must have a DimensionsId and/or Dimensions, currently both are default/null");
        if (viewModel.TypeId == default && viewModel.Type == null)
            throw new ArgumentNullException(nameof(viewModel.Type),"Placeable must have a TypeId and/or Type, currently both are default/null");
        if (viewModel.Type == null)
            throw new ArgumentNullException(nameof(viewModel.Type));
        
        var timeModified = (DateTime)(viewModel.Modified ?? viewModel.Created!);
        
        if (viewModel.Specie != null)
        {
            
            if (viewModel.Type is not PlantType)
                throw new ArgumentException("If Placeable has Specie, Type must be a PlantType", nameof(viewModel.Type));

            var plant = new Plant
            {
                Id = viewModel.Id,
                Created = (DateTime)viewModel.Created,
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

    public static PlaceableViewModel ToViewModel(Placeable placeable)
    {
        throw new NotImplementedException();
    }
}