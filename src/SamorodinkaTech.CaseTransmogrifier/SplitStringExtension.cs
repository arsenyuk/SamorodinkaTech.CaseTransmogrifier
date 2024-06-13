using System.Text;

namespace SamorodinkaTech.CaseTransmogrifier;

/// <summary>
/// Extension methods for parsing and splitting strings
/// </summary>
public static class SplitStringExtension
{
    private static readonly string WhiteSpace = " ";

    /// <summary>
    /// Parsing a string into components (by character types)
    /// </summary>
    public static string[] ParseCase(this string val)
    {
        if (string.IsNullOrEmpty(val))
        {
            return Array.Empty<string>();
        }

        var res = new StringBuilder();

        var partList = val.SplitByStandartSymbolSets();
        foreach (var p in partList)
        {
            if (p.ConsistsOfLetters())
            {
                var words = p.SplitByCase();

                foreach (var w in words)
                {
                    res.Append(w);
                    res.Append(WhiteSpace);
                }
                continue;
            }

            res.Append(p);
            res.Append(WhiteSpace);
        }

        return res
            .ToString()
            .SplitBySpace();
    }

    /// <summary>
    /// Split a string by spaces, ignoring empty lines
    /// </summary>
    public static string[] SplitBySpace(this string val)
    {
        return val.Split(
            new[] { WhiteSpace },
            System.StringSplitOptions.RemoveEmptyEntries
            );
    }

    /// <summary>
    /// Split a string by line break
    /// </summary>
    public static string[] SplitByNewline(this string val)
    {
        return val.Split(
            new[] { "\r\n", "\r", "\n" },
            StringSplitOptions.None
            ); ;
    }

    /// <summary>
    /// Split a string using groups from the standard character set
    /// </summary>
    public static string[] SplitByStandartSymbolSets(this string val)
    {
        if (string.IsNullOrEmpty(val))
            throw new ArgumentNullException(nameof(val));

        var res = new StringBuilder();

        var isDigit = false;
        var isLetter = false;

        for (var i = 0; i < val.Length; i++)
        {
            var ch = val[i];

            if (char.IsLetter(ch))
            {
                isLetter = true;
                if (isDigit)
                {
                    res.Append(WhiteSpace);
                }
                isDigit = false;
            }
            else
            if (char.IsDigit(ch))
            {
                isDigit = true;
                if (isLetter)
                {
                    res.Append(WhiteSpace); // TODO словарь аббревиатур
                }
                isLetter = false;
            }
            else
            {
                isDigit = false;
                isLetter = false;

                if (res.Length > 0)
                    res.Append(WhiteSpace);

                continue;
            }

            res.Append(ch);
        }

        return res
            .ToString()
            .SplitBySpace();
    }

    /// <summary>
    /// Split a string by case
    /// </summary>
    public static string[] SplitByCase(this string val)
    {
        if (string.IsNullOrEmpty(val))
            throw new ArgumentNullException(nameof(val));

        var res = new StringBuilder();

        if (string.IsNullOrEmpty(val))
            return Array.Empty<string>();

        var ch = val[val.Length - 1];

        var isPrevUpper = char.IsUpper(ch);
        var caps = isPrevUpper;

        res.Append(ch);

        for (var i = val.Length - 2; i >= 0; i--)
        {
            ch = val[i];

            var isUpper = char.IsUpper(ch);

            if (isPrevUpper && (!caps || !isUpper))
            {
                res.Append(WhiteSpace);
            }

            caps = isPrevUpper && isUpper;

            isPrevUpper = isUpper;

            res.Append(ch);
        }

        return (new string(res
            .ToString()
            .Reverse()
            .ToArray()))
            .SplitBySpace();
    }

    /// <summary>
    /// Check a string consists of only letters
    /// </summary>
    public static bool ConsistsOfLetters(this string val)
    {
        if (string.IsNullOrEmpty(val))
            throw new ArgumentNullException(nameof(val));

        for (var i = 0; i < val.Length; i++)
        {
            if (!char.IsLetter(val[i]))
                return false;
        }

        return true;
    }

    /// <summary>
    /// The string consists of only letters in one case
    /// </summary>
    public static bool ConsistsOfLettersInSameCase(this string val)
    {
        if (string.IsNullOrEmpty(val))
            throw new ArgumentNullException(nameof(val));

        var isUpper = false;

        for (var i = 0; i < val.Length; i++)
        {
            if (!char.IsLetter(val[i]))
                return false;

            if (i == 0)
            {
                isUpper = char.IsUpper(val[i]);
                continue;
            }

            if (char.IsUpper(val[i]) != isUpper)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Indicates that text contains capital letters without any lowercase letters.
    /// </summary>
    public static bool CheckAllCaps(this string val)
    {
        if (string.IsNullOrEmpty(val))
            throw new ArgumentNullException(nameof(val));

        for (var i = 0; i < val.Length; i++)
        {
            if (!char.IsUpper(val[i]))
                return false;
        }

        return true;
    }
}

