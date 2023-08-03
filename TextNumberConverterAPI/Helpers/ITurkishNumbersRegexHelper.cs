using System.Text.RegularExpressions;

namespace TextNumberConverterAPI.Helpers;

public interface ITurkishNumbersRegexHelper
{
    Regex GetNumberSearchRegex();

    Regex GetIntegerNumbersRegex();

    Dictionary<string, double> GetTextNumberMap();
}