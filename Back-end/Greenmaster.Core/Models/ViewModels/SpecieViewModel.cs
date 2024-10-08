﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Greenmaster.Core.Helpers.Attributes;
using Microsoft.AspNetCore.Http;
using StaticData.Coloring;
using StaticData.Geographic;
using StaticData.Gradation;
using StaticData.Object.Organic;
using StaticData.PlantProperties;
using StaticData.Taxonomy;
using StaticData.Time.Durations;

#pragma warning disable CS8618
namespace Greenmaster.Core.Models.ViewModels;

public class SpecieViewModel : IViewModelWithImage
{
    public int Id { get; set; }

    #region Naming

    [Required(ErrorMessage = "Specie must have a genus.")]
    public string Genus { get; set; }

    [Required(ErrorMessage = "Specie must have a species.")]
    public string Species { get; set; }

    public string? Cultivar { get; set; }

    [DisplayName("Scientific name")]
    public string ScientificName => $"{Genus} {Species}" + (string.IsNullOrEmpty(Cultivar) ? "" : $" '{Cultivar}'");

    [DisplayName("Common names")]
    public string CommonNames { get; set; }

    #endregion

    [DataType(DataType.MultilineText)]
    public string Description { get; set; }
    public Shape Shape { get; set; }

    [AtLeastOneRequired(new[] { $"{nameof(PlantType)}", $"{nameof(PlantTypeId)}" },
        ErrorMessage = $"At least one of {nameof(PlantType)} or {nameof(PlantTypeId)} is required.")]
    [DisplayName("Plant-type")]
    public int PlantTypeId { get; set; }
    
    [AtLeastOneRequired(new[] { $"{nameof(PlantType)}", $"{nameof(PlantTypeId)}" },
        ErrorMessage = $"At least one of {nameof(PlantType)} or {nameof(PlantTypeId)} is required.")]
    [DisplayName("Plant-type")]
    public PlantType? PlantType { get; set; }

    [Required(ErrorMessage = "Specie must have a Lifecycle")]
    public Lifecycle Lifecycle { get; set; }

    [DisplayName("Poisonous")] public bool IsPoisonous { get; set; }

    #region Requirements

    [Required]
    [DisplayName("Sunlight")]
    public Amount Sunlight { get; set; }

    [Required]
    [DisplayName("Water")]
    public Amount Water { get; set; }

    [Required]
    [DisplayName("Climate")]
    public ClimateType Climate { get; set; }
    
    [DisplayName("Min. temperature")]
    [Range(-40,40)]
    public int MinimalTemperature { get; set; }
    #endregion

    #region MaxDimensions

    [Required(ErrorMessage = "Specie must have a max. height.")]
    [DisplayName("Maximum height (metric)")]
    [Range(0.1, 150, ErrorMessage = "Max. height is invalid.")]
    public double MaxHeight { get; set; }

    [Required(ErrorMessage = "Specie must have a max. width.")]
    [DisplayName("Maximum width (metric)")]
    [Range(0.1, 10, ErrorMessage = "Max. width is invalid.")]
    public double MaxWidth { get; set; }

    #endregion

    #region FlowerInfo

    [DisplayName(displayName: "Blooming period")]
    public Month[] BloomPeriod { get; set; } = { Month.NotSet };

    [DisplayName("Flower colors")]
    public Color[]? FlowerColors { get; set; }

    [DisplayName("Fragrant flowers")] public bool IsFragrant { get; set; }

    [DisplayName("Flowers produce pollen")]
    public bool PollinatingFlowers { get; set; }

    #endregion
    [DisplayName("Mutualistic genera")]
    [AllowNull]
    public PlantGenus[] MutualisticGenera { get; set; }

    #region Media

    [AtLeastOneRequired(new[] { $"{nameof(Image)}", $"{nameof(ImageBase64)}" },
        ErrorMessage = $"At least one of {nameof(Image)} or {nameof(ImageBase64)} is required.")]
    public IFormFile? Image { get; set; }
    
    [AtLeastOneRequired(new[] { $"{nameof(Image)}", $"{nameof(ImageBase64)}" },
        ErrorMessage = $"At least one of {nameof(Image)} or {nameof(ImageBase64)} is required.")]
    public string? ImageBase64 { get; set; }


    #endregion

    /*[Required]
    [DisplayName("Preferred soil type")]
    public SoilType Soil { get; set; }
    
    //FertiliserData
    [DisplayName("Requires lime")]
    public bool RequiresLime { get; set; }
    [DisplayName("Nitrogen percentage")]
    [Range(1,99, ErrorMessage = "Nitrogen percentage is invalid.")]
    public int NitrogenLevel { get; set; }
    [DisplayName("Phosphor percentage")]
    [Range(1,99, ErrorMessage = "Phosphor percentage is invalid.")]
    public int PhosphorLevel { get; set; }
    [DisplayName("Potassium percentage")]
    [Range(1,99, ErrorMessage = "Potassium percentage is invalid.")]
    public int PotassiumLevel { get; set; }
    */
}
