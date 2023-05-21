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
            RequiresLargeGarden = gardenStyleViewModel.RequiresLargeGarden
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

    public static GardenStyleViewModel ToViewModel(GardenStyle gardenStyle)
    {
        throw new NotImplementedException();
    }
}