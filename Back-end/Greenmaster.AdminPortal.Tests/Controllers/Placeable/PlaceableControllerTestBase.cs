using Greenmaster.AdminPortal.Controllers;
using Greenmaster.Core.Examples;
using Greenmaster.Core.Factories;
using Greenmaster.Core.Models.Placeables;
using Greenmaster.Core.Models.ViewModels;
using Greenmaster.Core.Services.Placeables;

namespace Greenmaster.AdminPortal.Tests.Controllers.Placeable;

public abstract class PlaceableControllerTestBase
{
    protected readonly PlaceableController PlaceableController;
    protected readonly IPlantService PlantService = Substitute.For<IPlantService>();
    protected readonly IModelFactory<Core.Models.Placeables.Placeable, PlaceableViewModel> PlaceableFactory = Substitute.For<IModelFactory<Core.Models.Placeables.Placeable, PlaceableViewModel>>();
    protected readonly List<Plant> SomePlants;

    public PlaceableControllerTestBase()
    {
        PlaceableController = new PlaceableController(PlantService, PlaceableFactory);
        SomePlants = new List<Plant>()
        {
            PlaceableExamples.MaturePapaverPlant,
            PlaceableExamples.MatureStrelitziaPlant
        };
    }
}