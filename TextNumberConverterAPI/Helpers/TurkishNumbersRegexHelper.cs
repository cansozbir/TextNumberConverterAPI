using System.Text.RegularExpressions;

namespace TextNumberConverterAPI.Helpers;

public class TurkishNumbersRegexHelper : ITurkishNumbersRegexHelper
{
    private static readonly Dictionary<string, double> _textNumberMap = new()
    {
        {"sıfır", 0}, {"bir", 1}, {"iki", 2}, {"üç", 3}, {"dört", 4}, {"beş", 5}, {"altı", 6}, {"yedi", 7},
        {"sekiz", 8},
        {"dokuz", 9}, {"on", 10}, {"yirmi", 20}, {"otuz", 30}, {"kırk", 40}, {"elli", 50}, {"altmış", 60},
        {"yetmiş", 70}, {"seksen", 80}, {"doksan", 90}, {"yüz", 100}, {"bin", 1000}, {"milyon", 1000000},
        {"milyar", 1000000000}, {"trilyon", 1000000000000}, {"katrilyon", 1e15}
    };
    private const string Separators = @"[ ;:]";
    private const string NaturalNumbers = @"(?:[1-9][0-9]*)";
    private const string IntergerNumbers = @"-?[0-9]+";
    private const string DotSeparatedNumbers = @"[1-9]{1,2}(?:\.[0-9]{3})*";
    private const string DoubleNumbers = @"-?(?:(?:[0-9]*[,\.][0-9]+)|(?:[0-9]+[,\.][0-9]*))";
    private const string FractionalNumbers = $"{IntergerNumbers}/{NaturalNumbers}";
    private const string Numbers =
        $@"(?:(?:{IntergerNumbers})|(?:{DoubleNumbers})|(?:{FractionalNumbers})|(?:{DotSeparatedNumbers}))";
    private static readonly string NumberTexts = string.Join("|", _textNumberMap.Keys);
    private static readonly string AllNumbers = $@"(?:(?:{Numbers}|{NumberTexts})+)";

    private static readonly Regex IntegerNumbersRegex = new(IntergerNumbers);
    private static readonly Regex NumberSearchRegex = new(
        $@"(^|{Separators})({AllNumbers}(?: {AllNumbers})*)(?:{Separators}+|$)",
        RegexOptions.IgnoreCase);

    public Regex GetNumberSearchRegex()
    {
        return NumberSearchRegex;
    }

    public Regex GetIntegerNumbersRegex()
    {
        return IntegerNumbersRegex;
    }

    public Dictionary<string, double> GetTextNumberMap()
    {
        return _textNumberMap;
    }
}