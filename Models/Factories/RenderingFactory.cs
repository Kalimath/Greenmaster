using Greenmaster_ASP.Models.Static.Object.Rendering;
using Greenmaster_ASP.Models.ViewModels;
using NSubstitute;

namespace Greenmaster_ASP.Models.Factories;

public static class RenderingFactory
{
    public static Rendering Create(RenderingViewModel renderingViewModel)
    {
        return new Rendering(renderingViewModel.Id, renderingViewModel.ImageBase64, renderingViewModel.Type,
            renderingViewModel.Season);
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
}