using Greenmaster.Contracts.Commands.Graphic;
using Greenmaster.Contracts.Dto;
using Greenmaster.Core.Database.Base;
using Greenmaster.Core.Dxos.Image;
using Greenmaster.Core.Models.Graphic;
using MediatR;

namespace Greenmaster.Core.Database.Handlers.Commands;

public class AddImageCommandHandler : IRequestHandler<AddImageCommand, ImageDto>
{
    private readonly IRepository<Image> _imageRepository;
    private readonly IImageDxos _imageDxos;

    public AddImageCommandHandler(IRepository<Image> imageRepository, IImageDxos imageDxos)
    {
        _imageRepository = imageRepository;
        _imageDxos = imageDxos;
    }
    public async Task<ImageDto> Handle(AddImageCommand request, CancellationToken cancellationToken)
    {
        var image = new Image(request.Bytes,request.Description,request.FileExtension,request.Size);
        _imageRepository.Add(image);
        await _imageRepository.SaveChangesAsync();
        return _imageDxos.MapImageDto(image);
    }
}