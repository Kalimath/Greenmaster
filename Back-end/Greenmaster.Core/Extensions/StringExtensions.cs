using System.Text.RegularExpressions;

namespace Greenmaster.Core.Extensions;

public static class StringExtensions
{
    public static string PascalToKebabCase(this string input)
    {
        //split the string. Every time a letter is capitalized, it's a new word
        var words = Regex.Matches(input, @"\p{Lu}[\p{Ll}\p{N}]*")
           .Select(match => match.Value)
           .ToList();

        //join the words with hyphen
        return string.Join("-", words).ToLowerInvariant();
    }
}