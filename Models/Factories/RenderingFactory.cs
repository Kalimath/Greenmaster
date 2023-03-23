using Greenmaster_ASP.Helpers;
using Greenmaster_ASP.Models.ViewModels;
// ReSharper disable MethodNameNotMeaningful

namespace Greenmaster_ASP.Models.Factories;

public static class RenderingFactory
{
    public static async Task<Rendering> Create(RenderingViewModel renderingViewModel)
    {
        var rendering = new Rendering(renderingViewModel.Type, renderingViewModel.Season);
        
        SetId(rendering, renderingViewModel);
        await SetImage(rendering, renderingViewModel);
        
        return rendering;
    }

    public static RenderingViewModel ToViewModel(Rendering rendering)
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

    private static async Task SetImage(Rendering rendering, RenderingViewModel renderingViewModel)
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (renderingViewModel.Image != null)
        {
            rendering.Image = await FormFileConverter.ToBase64(renderingViewModel.Image);
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