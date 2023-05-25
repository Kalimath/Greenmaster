using Greenmaster_ASP.Models.Design;
using Greenmaster_ASP.Models.ViewModels;

namespace Greenmaster_ASP.Models.Factories;

public static class GardenStyleFactory
{
    public static GardenStyle Create(GardenStyleViewModel gardenStyleViewModel)
    {
        if (gardenStyleViewModel == null)
        {
            throw new ArgumentNullException(nameof(gardenStyleViewModel));
        }
        ValidateViewModel(gardenStyleViewModel);

        return new GardenStyle
        {
            Id = gardenStyleViewModel.Id,
            Name = gardenStyleViewModel.Name,
            Description = gardenStyleViewModel.Description,
            Concepts = gardenStyleViewModel.Concepts,
            Shapes = gardenStyleViewModel.Shapes,
            Colors = gardenStyleViewModel.Colors,
            RequiresLargeGarden = gardenStyleViewModel.RequiresLargeGarden,
            PathSize = gardenStyleViewModel.PathSize,
            Materials = gardenStyleViewModel.Materials
        };
    }
    
    public static GardenStyleViewModel ToViewModel(GardenStyle gardenStyle)
    {
        if (gardenStyle == null) throw new ArgumentNullException(nameof(gardenStyle));
        ValidateModel(gardenStyle);

        return new GardenStyleViewModel()
        {
            Id = gardenStyle.Id,
            Name = gardenStyle.Name,
            Description = gardenStyle.Description,
            Concepts = gardenStyle.Concepts,
            Shapes = gardenStyle.Shapes,
            Colors = gardenStyle.Colors,
            RequiresLargeGarden = gardenStyle.RequiresLargeGarden,
            PathSize = gardenStyle.PathSize,
            Materials = gardenStyle.Materials.ToArray()
        };
    }

    private static void ValidateViewModel(GardenStyleViewModel gardenStyleViewModel)
    {
        if (gardenStyleViewModel.Id<0)
            throw new ArgumentOutOfRangeException(nameof(gardenStyleViewModel.Id), "Id can't be < 0");
        if (string.IsNullOrWhiteSpace(gardenStyleViewModel.Name))
            throw new ArgumentException(nameof(gardenStyleViewModel.Name));
        if (string.IsNullOrWhiteSpace(gardenStyleViewModel.Description))
            throw new ArgumentException(nameof(gardenStyleViewModel.Description));
    }
    private static void ValidateModel(GardenStyle gardenStyle)
    {
        if (gardenStyle.Id<=0)
            throw new ArgumentOutOfRangeException(nameof(gardenStyle.Id), "Id must be greater than 0");
        if (string.IsNullOrWhiteSpace(gardenStyle.Name))
            throw new ArgumentException(nameof(gardenStyle.Name));
        if (string.IsNullOrWhiteSpace(gardenStyle.Description))
            throw new ArgumentException(nameof(gardenStyle.Description));
    }

}