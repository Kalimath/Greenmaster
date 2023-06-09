using Greenmaster.Core.Factories;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using NSubstitute;
// ReSharper disable SettingNotFoundInConfiguration

namespace Greenmaster.Core.Tests.Factories.Base;

public class RenderingFactoryTestBase
{
    protected readonly IModelFactory<Rendering, RenderingViewModel> RenderingFactory;
    protected const int MaxHeightConfig = 200;
    protected const int MaxWidthConfig = 100;
    protected static readonly IConfiguration Configuration = Substitute.For<IConfiguration>();
    
    
    protected RenderingFactoryTestBase()
    {
        RenderingFactory = new RenderingFactory(Configuration);
    }

    protected RenderingFactoryTestBase(int maxHeight, int maxWidth) : this()
    {
        //TODO: Fix incorrect substitution
        Configuration.GetSection("AppSettings").GetSection("Rendering").GetSection("Image")[Arg.Is("MaxHeight")].Returns(MaxHeightConfig.ToString());
        Configuration.GetSection("AppSettings").GetSection("Rendering").GetSection("Image")["MaxWidth"].Returns(MaxWidthConfig.ToString());
    }
}