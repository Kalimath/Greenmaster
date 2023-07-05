using Greenmaster.Core.Examples;
using Greenmaster.Core.Factories;
using Greenmaster.Core.Helpers;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.Extensions;
using Greenmaster.Core.Models.ViewModels;
using StaticData.Time.Durations;

namespace Greenmaster.Core.Tests.Factories.Base;

public class SpecieFactoryTestBase
{
    protected readonly IModelFactory<Specie, SpecieViewModel> SpecieFactory;
    protected SpecieViewModel SpecieViewModelStrelitzia;
    protected Specie SpecieStrelitzia;

    public SpecieFactoryTestBase()
    {
        SpecieFactory = new SpecieFactory();

        SpecieViewModelStrelitzia = new SpecieViewModel()
        {
            Id = SpecieExamples.Strelitzia.Id,
            Genus = SpecieExamples.Strelitzia.Genus.ToString(),
            Species = SpecieExamples.Strelitzia.Species,
            Cultivar = SpecieExamples.Strelitzia.Cultivar,
            CommonNames = SpecieExamples.Strelitzia.CommonNames,
            Description = SpecieExamples.Strelitzia.Description,
            PlantType = ObjectTypeExamples.SmallShrub,
            Shape = SpecieExamples.Strelitzia.Shape,
            Lifecycle = SpecieExamples.Strelitzia.Cycle,
            Sunlight = SpecieExamples.Strelitzia.Sunlight,
            Water = SpecieExamples.Strelitzia.Water,
            Climate = SpecieExamples.Strelitzia.Climate,
            MinimalTemperature = SpecieExamples.Strelitzia.MinimalTemperature,
            MaxHeight = SpecieExamples.Strelitzia.MaxHeight,
            MaxWidth = SpecieExamples.Strelitzia.MaxWidth,
            BloomPeriod = SpecieExamples.Strelitzia.BloomPeriod.Select(s => Enum.Parse<Month>(s)).ToArray(),
            AttractsPollinators = SpecieExamples.Strelitzia.AttractsPollinators,
            IsFragrant = SpecieExamples.Strelitzia.IsFragrant,
            IsPoisonous = SpecieExamples.Strelitzia.IsPoisonous,
            FlowerColors =SpecieExamples.Strelitzia.FlowerColors!.Select(s => s.ToColor()).ToArray(),
            Image = FormFileConverter.FromBase64(Base64Examples.ImageSpecie),
            ImageBase64 = SpecieExamples.Strelitzia.Image
        };

        SpecieStrelitzia = SpecieExamples.Strelitzia;
        SpecieStrelitzia.PlantType = ObjectTypeExamples.SmallShrub;
    }

    
}