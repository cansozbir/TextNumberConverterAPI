using TextNumberConverterAPI.Helpers;

namespace TextNumberConverterAPI.Services;

public class TextToNumberConverter : ITextToNumberConverter
{
    private readonly ITurkishNumbersRegexHelper _helper;

    public TextToNumberConverter(ITurkishNumbersRegexHelper helper)
    {
        _helper = helper;
    }

    public double ConvertToNumber(string text)
    {
        text = text.Replace(".", "");
        text = turkishLower(text);

        // Recursively handle fractions
        if (text.Contains(","))
        {
            var splits = text.Split(',');
            var fraction = ConvertToNumber(string.Join("", splits.Skip(1))) / Math.Pow(10, splits[1].Length);
            return ConvertToNumber(splits[0]) + fraction;
        }

        var numberList = new List<double>();
        var intNumberCache = "";
        var token = "";

        foreach (var ch in text)
        {
            token += ch;
            if (_helper.GetIntegerNumbersRegex().IsMatch(token.Trim()))
            {
                intNumberCache += token.Trim();
                token = "";
            }
            else if (_helper.GetTextNumberMap().TryGetValue(token.Trim(), out var number))
            {
                numberList.Add(number);
                token = "";
            }
            else if (intNumberCache.Length > 0)
            {
                numberList.Add(Convert.ToDouble(intNumberCache));
                intNumberCache = "";
                token = "";
            }
        }

        if (intNumberCache.Length > 0)
            numberList.Add(Convert.ToDouble(intNumberCache));

        return _getValue(numberList);
    }

    private double _getValue(List<double> numbers)
    {
        double res = 0;
        var i = numbers.Count - 1;
        var current_bin = 0; // bins -> 1e0, 1e3, 1e6...

        while (i >= 0)
        {
            if (numbers[i] % 1000 == 0)
            {
                // Make sure that bin is strictly increasing
                current_bin = numbers[i].ToString().Length - 1;

                // Find the associated value
                var j = i - 1;
                double temp_res = 0;
                while (j >= 0 && numbers[j] % 100 != 0)
                {
                    temp_res += numbers[j];
                    j--;
                }

                if (temp_res != 0) // Found a value
                {
                    res += temp_res * numbers[i];
                    i = j + 1;
                }
                else // No value found
                {
                    if (i == 0 || numbers[i - 1] % 100 != 0) res += numbers[i];
                }
            }
            else if (numbers[i] % 100 == 0)
            {
                // Find the value associated with 100 (its either in front with value [1-9] or there is none)
                if (i > 0 && numbers[i - 1] % 100 != 0)
                {
                    res += numbers[i - 1] * 100 * Math.Pow(10, current_bin);
                    i--;
                }
                else
                {
                    res += numbers[i] * Math.Pow(10, current_bin);
                }
            }
            else
            {
                res += numbers[i];
            }

            i--;
        }

        return res;
    }

    private string turkishLower(string input)
    {
        // TODO: Implement your turkishLower function logic here.
        // This function converts the input string to lowercase while handling Turkish-specific characters.
        // It should be a function that correctly handles the lowercase conversion of Turkish characters.
        // For simplicity, you can use the default C# lowercase conversion for now.
        return input.ToLower();
    }
}