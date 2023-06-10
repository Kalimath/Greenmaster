﻿using Greenmaster.Core.Examples;
using Greenmaster.Core.Factories;
using Greenmaster.Core.Models.Design;
using Greenmaster.Core.Models.ViewModels;
using StaticData.Measuring;

namespace Greenmaster.Core.Tests.Factories.Base;

public class GardenStyleFactoryTestBase
{
    protected GardenStyleViewModel GardenStyleViewModel;
    protected GardenStyle GardenStyle;
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