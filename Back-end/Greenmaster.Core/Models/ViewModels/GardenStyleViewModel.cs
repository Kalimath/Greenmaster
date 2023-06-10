using System.ComponentModel;
using StaticData.Measuring;

namespace Greenmaster.Core.Models.ViewModels;

public class GardenStyleViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string[] Concepts { get; set; }
    public string[] Shapes { get; set; }
    public string[] Colors { get; set; }
    [DisplayName(displayName: "Large garden only")]
    public bool RequiresLargeGarden { get; set; }

    public Size PathSize { get; set; }

    [DisplayName(displayName: "Material types")]
    public int[] MaterialTypeIds { get; set; }
    public MaterialType[]? Materials { get; set; }

    //TODO: add media 
}