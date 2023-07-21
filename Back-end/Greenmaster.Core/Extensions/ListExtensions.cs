using StaticData.Time.Durations;

namespace Greenmaster.Core.Extensions;

public static class ListExtensions
{
    public static string ToCsvString(this IEnumerable<Month> iEnumerable)
    {
        var result = "";
        foreach (var month in iEnumerable)
        {
            if (result != "")
            {
                result += ',';
            }
            result += month.ToString();
        }

        return result;
    }
}