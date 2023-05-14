using System.ComponentModel.DataAnnotations;
using eu.mbdevelopment.greenmaster.Domain.Base;
using eu.mbdevelopment.greenmaster.Domain.Shared.Validators;
using eu.mbdevelopment.greenmaster.Enum.Object.Rendering;
using eu.mbdevelopment.greenmaster.Enum.Time.Duration;

namespace eu.mbdevelopment.greenmaster.Domain.Renderable;

public class Rendering : BaseEntity
{
    private string _image;
    [Required] public string Image
    {
        get => _image;
        set
        {
            StringValidator.ValidateStringAndBase64(value);
            _image = value;
        }
    }
    [Required] public Season Season { get; set; }
    [Required] public RenderingObjectType Type { get; set; }

    public Rendering()
    {
        
    }
    
    public Rendering(RenderingObjectType type, Season? season)
    {
        Season = (Season)season!;
        Type = type;
    }
    
    public Rendering(Guid id, string base64Image, RenderingObjectType type, Season? season = Season.NotSet): this(type, season)
    {
        Id = id;
        Image = base64Image;
    }

    
}