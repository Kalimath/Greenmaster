using eu.greenmaster.Models;
using eu.greenmaster.Models.Static.Object.Rendering;
using eu.greenmaster.Models.Static.Time.Durations;

namespace eu.greenmaster.Examples;

public class RenderingExamples
{
    public static readonly Rendering FallTree = new (1, Base64Examples.ImageRendering, RenderingObjectType.Plant, Season.Autumn);
    public static readonly Rendering SummerTree = new (2, Base64Examples.ImageRendering, RenderingObjectType.Plant, Season.Summer);
    public static List<Rendering> GetAll()
    {
        return new List<Rendering>()
        {
            FallTree, SummerTree
        };
    }
}