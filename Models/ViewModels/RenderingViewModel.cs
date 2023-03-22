using System.ComponentModel.DataAnnotations;
using Greenmaster_ASP.Models.Static.Object.Rendering;
using Greenmaster_ASP.Models.Static.Time.Durations;

namespace Greenmaster_ASP.Models.ViewModels;

public class RenderingViewModel
{
    public int Id { get; set; }
    [Required]
    public string ImageBase64 { get; set; }
    [Required]
    public RenderingObjectType Type { get; set; }
    public Season? Season { get; set; } = Static.Time.Durations.Season.NotSet;
}