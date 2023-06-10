namespace Greenmaster.Core.Configuration;

public class RenderingConfig
{
    public ImageConfig Image { get; set; }

    public class ImageConfig
    {
        public int MaxHeight { get; set; }
        public int MaxWidth { get; set; }
    }
}