using Greenmaster.Core.Examples;
using Greenmaster.Core.Mappers;
using Greenmaster.Core.Models.Design;
using Greenmaster.Core.Models.ViewModels;
using StaticData.Measuring;

namespace Greenmaster.Core.Tests.Mappers.Base;

public class GardenStyleMapperTestBase
{
    protected readonly GardenStyleViewModel GardenStyleViewModel;
    protected readonly GardenStyle GardenStyle;
    protected readonly IViewModelMapper<GardenStyle, GardenStyleViewModel> GardenStyleMapper;

    public GardenStyleMapperTestBase()
    {
        GardenStyleMapper = new GardenStyleMapper();
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