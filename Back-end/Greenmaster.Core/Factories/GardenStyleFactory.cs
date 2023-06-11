using Greenmaster.Core.Models.ViewModels;

namespace Greenmaster.Core.Factories;

public class GardenStyleFactory : IModelFactory<GardenStyle, GardenStyleViewModel>
{
    public Task<GardenStyle> Create(GardenStyleViewModel gardenStyleViewModel)
    {
        if (gardenStyleViewModel == null)
        {
            throw new ArgumentNullException(nameof(gardenStyleViewModel));
        }
        ValidateViewModel(gardenStyleViewModel);

        return Task.FromResult(new GardenStyle
        {
            Id = gardenStyleViewModel.Id,
            Name = gardenStyleViewModel.Name,
            Description = gardenStyleViewModel.Description,
            Concepts = gardenStyleViewModel.Concepts,
            Shapes = gardenStyleViewModel.Shapes,
            Colors = gardenStyleViewModel.Colors,
            RequiresLargeGarden = gardenStyleViewModel.RequiresLargeGarden,
            AllSeasonInterest = gardenStyleViewModel.AllSeasonInterest,
            DivideIntoRooms = gardenStyleViewModel.DivideIntoRooms,
            PathSize = gardenStyleViewModel.PathSize,
            Materials = gardenStyleViewModel.Materials
        });
    }
    
    public GardenStyleViewModel ToViewModel(GardenStyle gardenStyle)
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
            AllSeasonInterest = gardenStyle.AllSeasonInterest,
            DivideIntoRooms = gardenStyle.DivideIntoRooms,
            PathSize = gardenStyle.PathSize,
            Materials = (gardenStyle.Materials ?? new List<MaterialType>()).ToArray()
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