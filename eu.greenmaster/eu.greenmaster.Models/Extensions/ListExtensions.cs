using eu.greenmaster.Models.StaticData.Time.Durations;

namespace eu.greenmaster.Models.Extensions;

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