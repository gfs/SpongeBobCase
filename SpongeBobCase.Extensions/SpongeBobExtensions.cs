using System.Globalization;
using System.Text;

namespace SpongeBobCase.Extensions;

public static class SpongeBobExtensions
{
    public static string ToSpongeBobCase(this string str)
    {
        ArgumentNullException.ThrowIfNull(str, nameof(str));
        return str.ToSpongeBobCase(CultureInfo.CurrentCulture);
    }
    
    public static string ToSpongeBobCase(this string str, CultureInfo culture)
    {
        ArgumentNullException.ThrowIfNull(str, nameof(str));
        ArgumentNullException.ThrowIfNull(culture, nameof(culture));

        return culture.TextInfo.ToSpongeBobCase(str);
    }

    private static string ToSpongeBobCase(this TextInfo textInfo, string stringToSpongeBob)
    {
        ArgumentNullException.ThrowIfNull(textInfo, nameof(textInfo));
        ArgumentNullException.ThrowIfNull(stringToSpongeBob, nameof(stringToSpongeBob));

        StringBuilder builder = new();
        bool useUpperCase = true;
        foreach(char character in stringToSpongeBob)
        {
            if (char.IsWhiteSpace(character))
            {
                builder.Append(character);
            }
            else
            {
                builder.Append(useUpperCase ? textInfo.ToUpper(character) : textInfo.ToLower(character));
                useUpperCase = !useUpperCase;                
            }
        }

        return builder.ToString();
    }
}