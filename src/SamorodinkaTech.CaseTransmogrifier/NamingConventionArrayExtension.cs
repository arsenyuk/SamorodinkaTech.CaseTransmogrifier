using System.Globalization;

namespace SamorodinkaTech.CaseTransmogrifier;

/// <summary>
/// Extension methods for an array of strings to form a style
/// </summary>
public static class NamingConventionArrayExtension
{
    /// <summary>
    /// Convert all array strings to lower case
    /// </summary>
    public static string[] ApplyLowerCase(this string[] arr)
    {
        return arr
            .Select(s => s.ToLowerInvariant())
            .ToArray();
    }

    /// <summary>
    /// Convert all array strings to title case
    /// </summary>
    public static string[] ApplyTitleCase(this string[] arr)
    {
        var ti = CultureInfo.CurrentCulture.TextInfo;

        return arr
            .Select(s => ti.ToTitleCase(s.ToLowerInvariant()))
            .ToArray();
    }

    /// <summary>
    /// Convert all array strings to camel case
    /// </summary>
    public static string[] ApplyCamelCase(this string[] arr)
    {
        var ti = CultureInfo.CurrentCulture.TextInfo;

        return arr
            .Select((s, i) => CaseSelector(s, i))
            .ToArray();

        string CaseSelector(string s, int i)
        {
            return i == 0
                ? s.ToLowerInvariant()
                : ti.ToTitleCase(s.ToLowerInvariant());
        }
    }

    /// <summary>
    /// Concatenates all elements of a string array without a separator between each element.
    /// </summary>
    public static string JoinToFontCase(this string[] arr)
    {
        return string.Join(string.Empty, arr);
    }

    private static readonly string Underscore = "_";

    /// <summary>
    /// Concatenates all elements of a string array using an underscore between each element.
    /// </summary>
    public static string JoinToSnake(this string[] arr)
    {
        return string.Join(Underscore, arr);
    }

    private static readonly string Hyphen = "-";

    /// <summary>
    /// Concatenates all elements of a string array using an hypen between each element.
    /// </summary>
    public static string JoinToKebab(this string[] arr)
    {
        return string.Join(Hyphen, arr);
    }
}
