using System.ComponentModel.DataAnnotations;
using Greenmaster.Core.Helpers.Attributes;
using Microsoft.AspNetCore.Http;
using StaticData.Object.Rendering;
using StaticData.Time.Durations;
using static StaticData.Time.Durations.Season;

namespace Greenmaster.Core.Models.ViewModels;

public class RenderingViewModel : IViewModelWithImage
{
    public int Id { get; set; }
    
    [Required]
    public RenderingObjectType Type { get; set; }
    public Season? Season { get; set; } = NotSet;
    
    [AtLeastOneRequired(new[] { $"{nameof(Image)}", $"{nameof(ImageBase64)}" },
        ErrorMessage = $"At least one of {nameof(Image)} or {nameof(ImageBase64)} is required.")]
    public IFormFile Image { get; set; }
    
    [AtLeastOneRequired(new[] { $"{nameof(Image)}", $"{nameof(ImageBase64)}" },
        ErrorMessage = $"At least one of {nameof(Image)} or {nameof(ImageBase64)} is required.")]
    public string? ImageBase64 { get; set; }
}