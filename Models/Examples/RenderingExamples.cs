using Greenmaster_ASP.Models.Static.Object.Rendering;
using Greenmaster_ASP.Models.Static.Time.Durations;

namespace Greenmaster_ASP.Models.Examples;

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