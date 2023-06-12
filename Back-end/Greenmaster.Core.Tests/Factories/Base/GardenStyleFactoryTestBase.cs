using Greenmaster.Core.Examples;
using Greenmaster.Core.Factories;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.Design;
using Greenmaster.Core.Models.ViewModels;
using StaticData.Measuring;
using StaticData.Taxonomy;

namespace Greenmaster.Core.Tests.Factories.Base;

public class GardenStyleFactoryTestBase
{
    protected readonly GardenStyleViewModel GardenStyleViewModel;
    protected readonly GardenStyle GardenStyle;
    protected readonly IModelFactory<GardenStyle, GardenStyleViewModel> GardenStyleFactory;

    public GardenStyleFactoryTestBase()
    {
        GardenStyleFactory = new GardenStyleFactory();
        GardenStyleViewModel = new GardenStyleViewModel()
        {
            Id = 1,
            Name = GardenStyleExamples.ModernAndMinimal.Name,
            Description = GardenStyleExamples.ModernAndMinimal.Description,
            Concepts = GardenStyleExamples.ModernAndMinimal.Concepts,
            Colors = GardenStyleExamples.ModernAndMinimal.Colors,
            Shapes = GardenStyleExamples.ModernAndMinimal.Shapes,
            RequiresLargeGarden = GardenStyleExamples.ModernAndMinimal.RequiresLargeGarden,
            AllSeasonInterest = GardenStyleExamples.ModernAndMinimal.AllSeasonInterest,
            PathSize = Size.Medium,
            Materials = new []
            {
                MaterialTypeExamples.Wood,
                MaterialTypeExamples.Stone,
                MaterialTypeExamples.Brick,
                MaterialTypeExamples.CortenSteel
            },
            SuitablePlantGenera = GardenStyleExamples.ModernAndMinimal.SuitablePlantGenera
            
        };
        GardenStyle = new GardenStyle
        {
            Id = 1,
            Name = GardenStyleExamples.ModernAndMinimal.Name,
            Description = GardenStyleExamples.ModernAndMinimal.Description,
            Concepts = GardenStyleExamples.ModernAndMinimal.Concepts,
            Colors = GardenStyleExamples.ModernAndMinimal.Colors,
            Shapes = GardenStyleExamples.ModernAndMinimal.Shapes,
            RequiresLargeGarden = GardenStyleExamples.ModernAndMinimal.RequiresLargeGarden,
            AllSeasonInterest = GardenStyleExamples.ModernAndMinimal.AllSeasonInterest,
            PathSize = Size.Medium,
            Materials = new []
            {
                MaterialTypeExamples.Wood,
                MaterialTypeExamples.Stone,
                MaterialTypeExamples.Brick,
                MaterialTypeExamples.CortenSteel
            },
            SuitablePlantGenera = GardenStyleExamples.ModernAndMinimal.SuitablePlantGenera
        };
    }
}