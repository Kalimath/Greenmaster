using Greenmaster.Core.Helpers.Attributes;
using Microsoft.AspNetCore.Http;

namespace Greenmaster.Core.Models.ViewModels;

public interface IViewModelWithImage
{
    [AtLeastOneRequired(new[] { $"{nameof(Image)}", $"{nameof(ImageBase64)}" },
        ErrorMessage = $"At least one of {nameof(Image)} or {nameof(ImageBase64)} is required.")]
    public IFormFile Image { get; set; }
    
    [AtLeastOneRequired(new[] { $"{nameof(Image)}", $"{nameof(ImageBase64)}" },
        ErrorMessage = $"At least one of {nameof(Image)} or {nameof(ImageBase64)} is required.")]
    public string? ImageBase64 { get; set; }
}