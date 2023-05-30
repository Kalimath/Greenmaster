using Greenmaster.Core.Examples;
using Greenmaster.Core.Models.Design;
using Greenmaster.Core.Models.ViewModels;
using StaticData.Measuring;

namespace Greenmaster.Core.Tests.Factories.GardenStyleFactoryTests;

public class GardenStyleFactoryTestBase
{
    protected GardenStyleViewModel GardenStyleViewModel;
    protected GardenStyle GardenStyle;

    public GardenStyleFactoryTestBase()
    {
        GardenStyleViewModel = new GardenStyleViewModel()
        {
            Id = 1,
            Name = GardenStyleExamples.ModernAndMinimal.Name,
            Description = GardenStyleExamples.ModernAndMinimal.Description,
            Concepts = GardenStyleExamples.ModernAndMinimal.Concepts,
            Colors = GardenStyleExamples.ModernAndMinimal.Colors,
            Shapes = GardenStyleExamples.ModernAndMinimal.Shapes,
            RequiresLargeGarden = GardenStyleExamples.ModernAndMinimal.RequiresLargeGarden,
            PathSize = Size.Medium,
            Materials = new []
            {
                MaterialTypeExamples.Wood,
                MaterialTypeExamples.Stone,
                MaterialTypeExamples.Brick,
                MaterialTypeExamples.CortenSteel
            }
            
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
            PathSize = Size.Medium,
            Materials = new []
            {
                MaterialTypeExamples.Wood,
                MaterialTypeExamples.Stone,
                MaterialTypeExamples.Brick,
                MaterialTypeExamples.CortenSteel
            }
        };
    }
}