namespace Greenmaster.Contracts.Dto;

public class ImageDto
{
    public byte[] Bytes { get; set; }
    public string Description { get; set; }
    public string FileExtension { get; set; }
    public int Size { get; set; }
}