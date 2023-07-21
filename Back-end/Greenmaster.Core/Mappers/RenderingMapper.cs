using System.Diagnostics.CodeAnalysis;
using Greenmaster.Core.Configuration;
using Greenmaster.Core.Helpers;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.ViewModels;
using Microsoft.Extensions.Options;

// ReSharper disable MethodNameNotMeaningful

namespace Greenmaster.Core.Mappers;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public class RenderingMapper : IViewModelMapper<Rendering, RenderingViewModel>
{
    private readonly IOptions<RenderingConfig> _configuration;
    
    public RenderingMapper(IOptions<RenderingConfig> configuration)
    {
        _configuration = configuration;
    }

    public async Task<Rendering> ToModel(RenderingViewModel renderingViewModel)
    {
        var rendering = new Rendering(renderingViewModel.Type, renderingViewModel.Season);
        
        SetId(rendering, renderingViewModel);
        await SetImage(rendering, renderingViewModel);
        
        return rendering;
    }

    public RenderingViewModel ToViewModel(Rendering rendering)
    {
        return new RenderingViewModel()
        {
            Id = rendering.Id,
            ImageBase64 = rendering.Image,
            Type = rendering.Type,
            Season = rendering.Season
        };
    }

    private static void SetId(Rendering rendering, RenderingViewModel renderingViewModel)
    {
        if (renderingViewModel.Id < 0)
            throw new ArgumentOutOfRangeException();
        
        rendering.Id = renderingViewModel.Id;
    }

    private async Task SetImage(Rendering rendering, RenderingViewModel renderingViewModel)
    {
        var renderSettings = _configuration.Value;
        
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (renderingViewModel.Image != null)
        {
            var initialImage = ImageConverter.FromBase64(await FormFileConverter.ToBase64(renderingViewModel.Image));
            
            var maxHeightConfig = renderSettings.Image.MaxHeight;
            var maxWidthConfig = renderSettings.Image.MaxWidth;
            
            //set image size to original image if not specified in config
            var imageHeight = (maxHeightConfig >= initialImage.Height) ? initialImage.Height : maxHeightConfig;
            var imageWidth = (maxWidthConfig >= initialImage.Width) ? initialImage.Width : maxWidthConfig;
            
            rendering.Image = ImageConverter.ToBase64(ImageConverter.Resize(initialImage, imageWidth, imageHeight));
        }
        else
        {
            if (StringValidator.IsValidAndBase64String(renderingViewModel.ImageBase64!))
                rendering.Image = renderingViewModel.ImageBase64!;
            else
                throw new ArgumentException(
                    $"Given {nameof(renderingViewModel)} has invalid {nameof(renderingViewModel.Image)} and/or {nameof(renderingViewModel.ImageBase64)}");
        }
    }
}