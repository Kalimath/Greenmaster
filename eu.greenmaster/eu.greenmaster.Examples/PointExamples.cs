using eu.greenmaster.Models;

namespace eu.greenmaster.Examples;

public class PointExamples
{
    public static readonly Point PointOne = new()
    {
        Id = 21,
        X = 33,
        Y = 68,
        Z = 340
    };
    public static readonly Point PointTwo = new()
    {
        Id = 22,
        X = 122,
        Y = 687,
        Z = 3
    };
    
    
    public static List<Point> GetAll()
    {
        return new List<Point>()
        {
            PointOne, PointTwo
        };
    }
}