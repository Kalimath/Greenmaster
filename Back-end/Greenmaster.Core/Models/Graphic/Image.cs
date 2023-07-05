using Greenmaster.Core.Models.Base;

namespace Greenmaster.Core.Models.Graphic;

public class Image : BaseAuditableEntity
{
    public byte[] Bytes { get; set; }
    public string Description { get; set; }
    public string FileExtension { get; set; }
    public int Size { get; set; }

    public Image(byte[] bytes, string fileExtension, int size)
    {
        Bytes = bytes;
        FileExtension = fileExtension;
        Size = size;
           
    }
    public Image(byte[] bytes, string description, string fileExtension, int size) : this(bytes, fileExtension, size)
    {
        Description = description;
    }
}