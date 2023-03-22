using Greenmaster_ASP.Helpers;
using Greenmaster_ASP.Models.Static;
using Greenmaster_ASP.Models.StaticData.Time.Durations;
using Greenmaster_ASP.Models.ViewModels;
using static Greenmaster_ASP.Helpers.StringValidator;

namespace Greenmaster_ASP.Models.Factories;

public class SpecieFactory
{
    public static async Task<Specie> Create(SpecieViewModel specieViewModel)
    {
        if (specieViewModel == null)
            throw new ArgumentNullException(nameof(specieViewModel));
        ValidateDimensions(specieViewModel.MaxHeight, specieViewModel.MaxWidth);

        var specie = new Specie
        {
            Id = specieViewModel.Id,
            Genus = specieViewModel.Genus,
            Species = specieViewModel.Species,
            Cultivar = specieViewModel.Cultivar,
            CommonNames = specieViewModel.CommonNames,
            Description = specieViewModel.Description,
            PlantType = specieViewModel.Type,
            Shape = specieViewModel.Shape,
            Cycle = specieViewModel.Lifecycle,
            Sunlight = specieViewModel.Sunlight,
            Water = specieViewModel.Water,
            Climate = specieViewModel.Climate,
            IsPoisonous = specieViewModel.IsPoisonous,

            MaxHeight = specieViewModel.MaxHeight,
            MaxWidth = specieViewModel.MaxWidth,

            BloomPeriod =
                (specieViewModel.BloomPeriod ?? throw new ArgumentNullException(nameof(specieViewModel.BloomPeriod)))
                .Select(a => a.ToString()).ToArray(),
            FlowerColors =
                (specieViewModel.FlowerColors ?? throw new ArgumentNullException(nameof(specieViewModel.FlowerColors)))
                .Select(a => a.ToString()).ToArray(),
            IsFragrant = specieViewModel.IsFragrant,
            AttractsPollinators = specieViewModel.AttractsPollinators,
        };
        await SetSpecieImage(specie, specieViewModel);
        return specie;
    }

    private static async Task SetSpecieImage(Specie specie, SpecieViewModel specieViewModel)
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (specieViewModel.Image != null)
        {
            specie.Image = await FormFileConverter.ToBase64(specieViewModel.Image);
        }
        else
        {
            if (IsValidAndBase64String(specieViewModel.ImageBase64))
                specie.Image = specieViewModel.ImageBase64;
            else
                throw new ArgumentException(
                    $"Given {nameof(specieViewModel)} has invalid {nameof(specieViewModel.Image)} and/or {nameof(specieViewModel.ImageBase64)}");
        }
    }

    private static void ValidateDimensions(double maxHeight, double maxWidth)
    {
        if (maxHeight > 150 || maxHeight < 0.1)
            throw new ArgumentOutOfRangeException(nameof(maxHeight), $"Invalid value: {maxHeight}");

        if (maxWidth > 10 || maxWidth < 0.1)
            throw new ArgumentOutOfRangeException(nameof(maxWidth), $"Invalid value: {maxWidth}");
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
        ValidateImageBase64(specie.Image);

        return new SpecieViewModel()
        {
            Id = specie.Id,
            Genus = specie.Genus,
            Species = specie.Species,
            Cultivar = specie.Cultivar,
            CommonNames = specie.CommonNames,
            Description = specie.Description,
            Type = specie.PlantType,
            Shape = specie.Shape,
            Lifecycle = specie.Cycle,
            Sunlight = specie.Sunlight,
            Water = specie.Water,
            Climate = specie.Climate,
            IsPoisonous = specie.IsPoisonous,

            MaxHeight = specie.MaxHeight,
            MaxWidth = specie.MaxWidth,

            BloomPeriod = (specie.BloomPeriod ?? throw new ArgumentNullException(nameof(specie.BloomPeriod)))
                .Select(s => Enum.Parse<Month>(s)).ToArray(),
            FlowerColors = (specie.FlowerColors ?? throw new ArgumentNullException(nameof(specie.FlowerColors)))
                .Select(s => Enum.Parse<Color>(s)).ToArray(),
            IsFragrant = specie.IsFragrant,
            AttractsPollinators = specie.AttractsPollinators,

            Image = null!,
            ImageBase64 = specie.Image
        };
    }
}