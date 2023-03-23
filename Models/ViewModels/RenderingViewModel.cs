using System.ComponentModel.DataAnnotations;
using Greenmaster_ASP.Helpers.Attributes;
using Greenmaster_ASP.Models.Static.Object.Rendering;
using Greenmaster_ASP.Models.Static.Time.Durations;

namespace Greenmaster_ASP.Models.ViewModels;

public class RenderingViewModel : ViewModelWithImage
{
    public int Id { get; set; }
    
    [Required]
    public RenderingObjectType Type { get; set; }
    public Season? Season { get; set; } = Static.Time.Durations.Season.NotSet;
}

public abstract class ViewModelWithImage
{
    [AtLeastOneRequired(new[] { $"{nameof(Image)}", $"{nameof(ImageBase64)}" },
        ErrorMessage = $"At least one of {nameof(Image)} or {nameof(ImageBase64)} is required.")]
    public IFormFile Image { get; set; }
    
    [AtLeastOneRequired(new[] { $"{nameof(Image)}", $"{nameof(ImageBase64)}" },
        ErrorMessage = $"At least one of {nameof(Image)} or {nameof(ImageBase64)} is required.")]
    public string? ImageBase64 { get; set; }
}