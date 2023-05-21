using Greenmaster_ASP.Models.Design;
using Greenmaster_ASP.Models.Examples;
using Greenmaster_ASP.Models.ViewModels;

namespace Greenmaster_ASP.Tests.UnitTests.Factories.GardenStyleFactoryTests;

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
            RequiresLargeGarden = GardenStyleExamples.ModernAndMinimal.RequiresLargeGarden
        };
        GardenStyle = new GardenStyle
        {
            Id = 1,
            Name = GardenStyleExamples.ModernAndMinimal.Name,
            Description = GardenStyleExamples.ModernAndMinimal.Description,
            Concepts = GardenStyleExamples.ModernAndMinimal.Concepts,
            Colors = GardenStyleExamples.ModernAndMinimal.Colors,
            Shapes = GardenStyleExamples.ModernAndMinimal.Shapes,
            RequiresLargeGarden = GardenStyleExamples.ModernAndMinimal.RequiresLargeGarden
        };
    }
}