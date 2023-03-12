using Greenmaster_ASP.Models.Extensions;
using Greenmaster_ASP.Models.Measurements;
using Greenmaster_ASP.Models.ViewModels;
using NotImplementedException = System.NotImplementedException;

namespace Greenmaster_ASP.Models.Factories;

public class SpecieFactory
{
    public static Specie Create(SpecieViewModel specieViewModel)
    {
        if (specieViewModel == null)
            throw new ArgumentNullException(nameof(specieViewModel));

        var maxDimensions = CreateDimensions(specieViewModel);

        var fertiliserData = CreateFertiliserInfo(specieViewModel);
        var flowerInfo = CreateFlowerInfo(specieViewModel);
        var requirements = CreatePlantRequirements(specieViewModel, fertiliserData);
        return new Specie()
        {
            /*ScientificName = specieViewModel.ScientificName,
            Type = specieViewModel.Type,
            Lifecycle = specieViewModel.Lifecycle,
            Requirements = requirements,
            FlowerInfo = flowerInfo,
            MaxDimensions = maxDimensions,*/

        };
    }

    private static Dimensions CreateDimensions(SpecieViewModel specieViewModel)
    {
        if (specieViewModel.MaxHeight > 50 || specieViewModel.MaxHeight < 0.1)
            throw new ArgumentOutOfRangeException(nameof(specieViewModel.MaxHeight));

        if (specieViewModel.MaxWidth > 10 || specieViewModel.MaxWidth < 0.1)
            throw new ArgumentOutOfRangeException(nameof(specieViewModel.MaxHeight));

        return new Dimensions()
        {
            Height = specieViewModel.MaxHeight,
            Width = specieViewModel.MaxWidth
        };
    }

    private static FlowerData CreateFlowerInfo(SpecieViewModel specieViewModel)
    {
        return new FlowerData()
        {
            Color = specieViewModel.Color,
            AttractsPollinators = specieViewModel.AttractsPollinators,
            FlowerPeriod = specieViewModel.FlowerPeriod.ToCsvString(),
            IsFragrant = specieViewModel.IsFragrant
        };
    }

    private static PlantRequirements CreatePlantRequirements(SpecieViewModel specieViewModel, FertiliserData fertiliserData)
    {
        return new PlantRequirements()
        {
            Climate = specieViewModel.Climate,
            Soil = specieViewModel.Soil,
            Sunlight = specieViewModel.Sunlight,
            Water = specieViewModel.Water,
            FertiliserInfo = fertiliserData
        };
    }

    private static FertiliserData CreateFertiliserInfo(SpecieViewModel specieViewModel)
    {
        var totalPercentage =
            (specieViewModel.NitrogenLevel + specieViewModel.PhosphorLevel + specieViewModel.PotassiumLevel);
        if (totalPercentage != 100)
            throw new ArgumentOutOfRangeException(
                $"NPP-levels together do not equal 100%, but equal to {totalPercentage}%");

        return new FertiliserData()
        {
            RequiresLime = specieViewModel.RequiresLime,
            NitrogenLevel = specieViewModel.NitrogenLevel,
            PhosphorLevel = specieViewModel.PhosphorLevel,
            PotassiumLevel = specieViewModel.PotassiumLevel
        };
    }

    public static SpecieViewModel ToViewModel(Specie specie)
    {
        throw new NotImplementedException();
    }
}