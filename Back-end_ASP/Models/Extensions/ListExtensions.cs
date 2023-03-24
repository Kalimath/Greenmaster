using Greenmaster_ASP.Models.StaticData.Time.Durations;

namespace Greenmaster_ASP.Models.Extensions;

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