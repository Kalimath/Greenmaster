using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster.Core.Helpers;
using StaticData.Object.Rendering;
using StaticData.Time.Durations;

namespace Greenmaster.Core.Models;

public class Rendering : IObjectIdentity
{
    private string _image;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }
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
    
    public Rendering(int id, string base64Image, RenderingObjectType type, Season? season = Season.NotSet): this(type, season)
    {
        Id = id;
        Image = base64Image;
    }

    
}