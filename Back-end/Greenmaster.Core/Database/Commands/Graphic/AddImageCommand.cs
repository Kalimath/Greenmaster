using Greenmaster.Contracts.Base;
using Greenmaster.Contracts.Dto;

namespace Greenmaster.Core.Database.Commands.Graphic;

public class AddImageCommand : CommandBase<ImageDto>
{
    public byte[] Bytes { get; set; }
    public string Description { get; set; }
    public string FileExtension { get; set; }
    public int Size { get; set; }
}