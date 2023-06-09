using System.Diagnostics.CodeAnalysis;
using Greenmaster.Core.Helpers;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.ViewModels;
using Microsoft.Extensions.Configuration;

// ReSharper disable MethodNameNotMeaningful

namespace Greenmaster.Core.Factories;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public class RenderingFactory : IModelFactory<Rendering, RenderingViewModel>
{
    private readonly IConfiguration _configuration;
    
    public RenderingFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    //TODO: fix failing tests due to missing configuration by Substitution of IConfiguration
    private static readonly IConfiguration Configuration = new ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory)
        .AddJsonFile(@"appsettings.json", false, false)
        .AddEnvironmentVariables()
        .Build();
    
    public async Task<Rendering> Create(RenderingViewModel renderingViewModel)
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
        var renderSettings = _configuration.GetSection($"AppSettings").GetSection($"Rendering");
        
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (renderingViewModel.Image != null)
        {
            var initialImage = ImageConverter.FromBase64(await FormFileConverter.ToBase64(renderingViewModel.Image));
            
            var maxHeightConfig = renderSettings.GetSection("Image")["MaxHeight"];
            var maxWidthConfig = renderSettings.GetSection("Image")["MaxWidth"];
            var maxHeight = string.IsNullOrWhiteSpace(maxHeightConfig) ?  initialImage.Height : int.Parse(maxHeightConfig);
            var maxWidth = string.IsNullOrWhiteSpace(maxWidthConfig) ?  initialImage.Width : int.Parse(maxWidthConfig);
            
            //set image size to original image if not specified in config
            var imageHeight = (maxHeight >= initialImage.Height) ? initialImage.Height : maxHeight;
            var imageWidth = (maxWidth >= initialImage.Width) ? initialImage.Width : maxWidth;
            
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