using System.ComponentModel.DataAnnotations;
using eu.greenmaster.Models.Helpers.Attributes;
using eu.greenmaster.Models.Static.Object.Rendering;
using eu.greenmaster.Models.Static.Time.Durations;
using Microsoft.AspNetCore.Http;

namespace eu.greenmaster.Models.ViewModels;

public class RenderingViewModel : IViewModelWithImage
{
    public int Id { get; set; }
    
    [Required]
    public RenderingObjectType Type { get; set; }
    public Season? Season { get; set; } = Static.Time.Durations.Season.NotSet;
    
    [AtLeastOneRequired(new[] { $"{nameof(Image)}", $"{nameof(ImageBase64)}" },
        ErrorMessage = $"At least one of {nameof(Image)} or {nameof(ImageBase64)} is required.")]
    public IFormFile Image { get; set; }
    
    [AtLeastOneRequired(new[] { $"{nameof(Image)}", $"{nameof(ImageBase64)}" },
        ErrorMessage = $"At least one of {nameof(Image)} or {nameof(ImageBase64)} is required.")]
    public string? ImageBase64 { get; set; }
}