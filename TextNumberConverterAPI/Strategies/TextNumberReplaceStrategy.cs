using System.Text;
using System.Text.RegularExpressions;
using TextNumberConverterAPI.Helpers;
using TextNumberConverterAPI.Services;

namespace TextNumberConverterAPI.Strategies;

public class TurkishTextNumberReplaceStrategy : ITextNumberReplaceStrategy
{
    private readonly ITextToNumberConverter _converter;
    private readonly ITurkishNumbersRegexHelper _helper;

    public TurkishTextNumberReplaceStrategy(ITurkishNumbersRegexHelper helper, ITextToNumberConverter converter)
    {
        _helper = helper;
        _converter = converter;
    }

    public string ReplaceAll(string text)
    {
        var sb = new StringBuilder(text);
        var offset = 0;

        foreach (Match match in _helper.GetNumberSearchRegex().Matches(text))
        {
            var startIndex = match.Index + match.Groups[1].Length - offset;
            var matchText = match.Groups[2].Value;

            // Convert the text number to its numerical value using the TextToNumberConverter

            try
            {
                var numberValue = _converter.ConvertToNumber(matchText);
                // Replace the text number with the numerical value
                sb.Remove(startIndex, matchText.Length);
                sb.Insert(startIndex, numberValue.ToString());
                offset += matchText.Length - numberValue.ToString().Length;
            }
            catch (Exception)
            {
                // If the text number cannot be converted, leave it as it is
            }
        }

        return sb.ToString();
    }
}