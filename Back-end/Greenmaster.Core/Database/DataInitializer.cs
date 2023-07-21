using Greenmaster.Core.Examples;
using Greenmaster.Core.Services.Example;

namespace Greenmaster.Core.Database;

public class DataInitializer
{
    private readonly ArboretumContext _applicationDbContext;
    private readonly IExamplesService _exampleService;

    public DataInitializer(ArboretumContext applicationDbContext, IExamplesService exampleService)
    {
        _applicationDbContext = applicationDbContext;
        _exampleService = exampleService;
    }

    public async Task<bool> SeedData()
    {
        await SeedDatabaseAsync();
        return true;
    }

    // ReSharper disable once CognitiveComplexity
    // ReSharper disable once MethodTooLong
    private async Task SeedDatabaseAsync()
    {
        if (!_applicationDbContext.Species.Any())
            await _applicationDbContext.Species.AddRangeAsync(_exampleService.GetAllSpecies());
        if (!_applicationDbContext.Dimensions.Any())
            await _applicationDbContext.Dimensions.AddRangeAsync(_exampleService.GetAllDimensions());
        if (!_applicationDbContext.Points.Any())
            await _applicationDbContext.Points.AddRangeAsync(_exampleService.GetAllPoints());
        if (!_applicationDbContext.MaterialTypes.Any())
            await _applicationDbContext.MaterialTypes.AddRangeAsync(_exampleService.GetAllMaterialTypes());
        if (!_applicationDbContext.PlantTypes.Any())
            await _applicationDbContext.PlantTypes.AddRangeAsync(_exampleService.GetAllPlantTypes());
        if (!_applicationDbContext.Plants.Any())
            await _applicationDbContext.Plants.AddRangeAsync(_exampleService.GetAllPlants());
        if (!_applicationDbContext.StructureTypes.Any())
            await _applicationDbContext.StructureTypes.AddRangeAsync(_exampleService.GetAllStructureTypes());
        if (!_applicationDbContext.Structures.Any())
            await _applicationDbContext.Structures.AddRangeAsync(_exampleService.GetAllStructures());
        if (!_applicationDbContext.GardenStyles.Any())
            await _applicationDbContext.GardenStyles.AddRangeAsync(_exampleService.GetAllGardenStyles());
        if (!_applicationDbContext.Renderings.Any())
            await _applicationDbContext.Renderings.AddRangeAsync(_exampleService.GetAllRenderings());
        if (!_applicationDbContext.Placeables.Any())
            await _applicationDbContext.Placeables.AddRangeAsync(_exampleService.GetAllPlaceables());

        await _applicationDbContext.SaveChangesAsync();
    }
}