using Greenmaster.Core.Configuration;
using Greenmaster.Core.Mappers;
using Greenmaster.Core.Models;
using Greenmaster.Core.Models.ViewModels;
using Microsoft.Extensions.Options;
using NSubstitute;

// ReSharper disable SettingNotFoundInConfiguration

namespace Greenmaster.Core.Tests.Mappers.Base;

public class RenderingMapperTestBase
{
    protected readonly IViewModelMapper<Rendering, RenderingViewModel> RenderingMapper;
    protected const int MaxHeightConfig = 200;
    protected const int MaxWidthConfig = 100;
    protected static readonly IOptions<RenderingConfig> Configuration = Substitute.For<IOptions<RenderingConfig>>();
    
    
    protected RenderingMapperTestBase()
    {
        RenderingMapper = new RenderingMapper(Configuration);
        DefineConfigReturnValues(MaxHeightConfig, MaxWidthConfig);
    }

    protected RenderingMapperTestBase(int maxHeight, int maxWidth) : this()
    {
        //TODO: Fix incorrect substitution
        DefineConfigReturnValues(maxHeight, maxWidth);
    }

    protected void DefineConfigReturnValues(int maxHeight, int maxWidth)
    {
        var renderingConfig = new RenderingConfig
        {
            Image = new RenderingConfig.ImageConfig
            {
                MaxHeight = maxHeight,
                MaxWidth = maxWidth
            }
        };
        Configuration.Value.Returns(renderingConfig);
    }
}