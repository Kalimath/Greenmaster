using AutoMapper;
using Greenmaster.Contracts.Dto;
// ReSharper disable All

namespace Greenmaster.Core.Dxos.Image;

public interface IImageDxos
{
    ImageDto MapImageDto(Models.Graphic.Image image);
    IEnumerable<ImageDto> MapImageDtos(IEnumerable<Models.Graphic.Image> images);
}

public class ImageDxos : IImageDxos
{
    private readonly IMapper _mapper;
    
    public ImageDxos()
    {
        var config = new MapperConfiguration(cfg => { cfg.CreateMap<Models.Graphic.Image, ImageDto>(); });
        _mapper = config.CreateMapper();
    }
    
    public ImageDto MapImageDto(Models.Graphic.Image image)
    {
        return _mapper.Map<ImageDto>(image);
    }

    public IEnumerable<ImageDto> MapImageDtos(IEnumerable<Models.Graphic.Image> images)
    {
        return _mapper.Map<IEnumerable<ImageDto>>(images);
    }
}