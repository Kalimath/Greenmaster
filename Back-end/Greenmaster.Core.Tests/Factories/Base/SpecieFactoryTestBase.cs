using Greenmaster.Core.Examples;
using Greenmaster.Core.Helpers;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.Extensions;
using Greenmaster.Core.Models.ViewModels;
using StaticData.Time.Durations;

namespace Greenmaster.Core.Tests.Factories.Base;

public class SpecieFactoryTestBase
{
    protected SpecieViewModel SpecieViewModelStrelitzia;
    protected Specie SpecieStrelitzia;

    public SpecieFactoryTestBase()
    {
        
        SpecieViewModelStrelitzia = new SpecieViewModel()
        {
            Id = 1,
            Genus = SpecieExamples.Strelitzia.Genus,
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