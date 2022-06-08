using System.Globalization;
using System.Text;

namespace SpongeBobCase.Extensions;

public static class SpongeBobExtensions
{
    /// <summary>
    /// Convert a string to SpOnGeBoB sArCaSm CaSe using <see cref="CultureInfo.CurrentCulture"/>
    /// </summary>
    /// <param name="str">A string.</param>
    /// <returns>ThE sAmE sTrInG, bUt sArCaStIc.</returns>
    public static string ToSpongeBobCase(this string str)
    {
        ArgumentNullException.ThrowIfNull(str, nameof(str));
        return str.ToSpongeBobCase(CultureInfo.CurrentCulture);
    }
    
    /// <summary>
    /// Convert a string to SpOnGeBoB sArCaSm CaSe using the specified <see cref="CultureInfo"/>
    /// </summary>
    /// <param name="str">A string.</param>
    /// <param name="culture">The culture to use.</param>
    /// <returns>ThE sAmE sTrInG, bUt sArCaStIc.</returns>
    public static string ToSpongeBobCase(this string str, CultureInfo culture)
    {
        ArgumentNullException.ThrowIfNull(str, nameof(str));
        ArgumentNullException.ThrowIfNull(culture, nameof(culture));

        return culture.TextInfo.ToSpongeBobCase(str);
    }

    /// <summary>
    /// Convert a string to SpOnGeBoB sArCaSm CaSe using the specified <see cref="TextInfo"/>
    /// </summary>
    /// <param name="stringToSpongeBob">A string.</param>
    /// <param name="textInfo">The culture to use.</param>
    /// <returns>ThE sAmE sTrInG, bUt sArCaStIc.</returns>
    public static string ToSpongeBobCase(this TextInfo textInfo, string stringToSpongeBob)
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