using Greenmaster_ASP.Models.StaticData.Time.Durations;
using Greenmaster_ASP.Models.ViewModels;

namespace Greenmaster_ASP.Models.Factories;

public class SpecieFactory
{
    public static Specie Create(SpecieViewModel specieViewModel)
    {
        if (specieViewModel == null)
            throw new ArgumentNullException(nameof(specieViewModel));
        ValidateDimensions(specieViewModel.MaxHeight, specieViewModel.MaxWidth);
        
        var stringifiedBloomPeriod = new string[specieViewModel.BloomPeriod.Length];
        for (var index = 0; index < specieViewModel.BloomPeriod.Length; index++)
        {
            stringifiedBloomPeriod[index] = specieViewModel.BloomPeriod[index].ToString();
        }
        
        return new Specie
        {
            Id = specieViewModel.Id,
            Genus = specieViewModel.Genus,
            Species = specieViewModel.Species,
            Cultivar = specieViewModel.Cultivar,
            CommonNames = specieViewModel.CommonNames,
            Description = specieViewModel.Description,
            PlantType = specieViewModel.Type,
            Cycle = specieViewModel.Lifecycle,
            MaxHeight = specieViewModel.MaxHeight,
            MaxWidth = specieViewModel.MaxWidth,
            BloomPeriod = stringifiedBloomPeriod
        };
    }

    private static void ValidateDimensions(double maxHeight, double maxWidth)
    {
        if (maxHeight > 150 || maxHeight < 0.1)
            throw new ArgumentOutOfRangeException(nameof(maxHeight));

        if (maxWidth > 10 || maxWidth < 0.1)
            throw new ArgumentOutOfRangeException(nameof(maxHeight));
    }
    /*

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
    }*/

    public static SpecieViewModel ToViewModel(Specie specie)
    {
        if (specie == null)
            throw new ArgumentNullException(nameof(specie));
        ValidateDimensions(specie.MaxHeight, specie.MaxWidth);
        
        var bloomPeriod = new Month[specie.BloomPeriod.Length];
        for (var index = 0; index < specie.BloomPeriod.Length; index++)
        {
            bloomPeriod[index] = Enum.Parse<Month>(specie.BloomPeriod[index]);
        }
        
        return new SpecieViewModel()
        {
            Id = specie.Id,
            Genus = specie.Genus,
            Species = specie.Species,
            Cultivar = specie.Cultivar,
            CommonNames = specie.CommonNames,
            Description = specie.Description,
            Type = specie.PlantType,
            Lifecycle = specie.Cycle,
            MaxHeight = specie.MaxHeight,
            MaxWidth = specie.MaxWidth,
            BloomPeriod = bloomPeriod
        };
    }
}