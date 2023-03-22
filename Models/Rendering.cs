using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Greenmaster_ASP.Helpers;
using Greenmaster_ASP.Models.Base;
using Greenmaster_ASP.Models.Static.Object.Rendering;
using Greenmaster_ASP.Models.Static.Time.Durations;

namespace Greenmaster_ASP.Models;

public class Rendering : BaseEntity
{
    private string _image;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }
    [Required] public string Image
    {
        get => _image;
        set
        {
            StringValidator.ValidateImageBase64(value);
            _image = value;
        }
    }
    [Required] public Season Season { get; set; }
    [Required] public RenderingObjectType Type { get; set; }

    public Rendering()
    {
        
    }
    public Rendering(int id, string base64Image, RenderingObjectType type, Season? season = Season.NotSet)
    {
        Season = (Season)season!;
        Image = base64Image;
        Type = type;
        Id = id;
    }
}