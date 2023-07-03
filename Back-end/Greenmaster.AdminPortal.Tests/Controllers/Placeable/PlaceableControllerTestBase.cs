using Greenmaster.AdminPortal.Controllers;
using Greenmaster.Core.Examples;
using Greenmaster.Core.Factories;
using Greenmaster.Core.Models.Placeables;
using Greenmaster.Core.Models.ViewModels;
using Greenmaster.Core.Services.Example;
using Greenmaster.Core.Services.Placeables;
using Greenmaster.Core.Services.Specie;

namespace Greenmaster.AdminPortal.Tests.Controllers.Placeable;

public abstract class PlaceableControllerTestBase
{
    protected readonly PlaceableController PlaceableController;
    protected readonly IPlantService PlantService = Substitute.For<IPlantService>();
    protected readonly IModelFactory<Core.Models.Placeables.Placeable, PlaceableViewModel> PlaceableFactory = Substitute.For<IModelFactory<Core.Models.Placeables.Placeable, PlaceableViewModel>>();
    protected readonly List<Plant> SomePlants;
    protected static readonly ISpecieService SpecieService = Substitute.For<ISpecieService>();
    protected static readonly IExamplesService ExamplesService = new ExamplesService();

    public PlaceableControllerTestBase()
    {
        PlaceableController = new PlaceableController(PlantService, SpecieService, PlaceableFactory);
        SomePlants = new List<Plant>()
        {
            PlaceableExamples.MaturePapaverPlant,
            PlaceableExamples.MatureStrelitziaPlant
        };
    }
}