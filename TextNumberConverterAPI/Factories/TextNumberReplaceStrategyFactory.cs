using TextNumberConverterAPI.Helpers;
using TextNumberConverterAPI.Services;
using TextNumberConverterAPI.Strategies;

namespace TextNumberConverterAPI.Factories;

public class TextNumberReplaceStrategyFactory : ITextNumberReplaceStrategyFactory
{
    private readonly ITextToNumberConverter _textToNumberConverter;
    private readonly ITurkishNumbersRegexHelper _turkishHelper;

    public TextNumberReplaceStrategyFactory(ITurkishNumbersRegexHelper turkishHelper,
        ITextToNumberConverter textToNumberConverter)
    {
        _turkishHelper = turkishHelper;
        _textToNumberConverter = textToNumberConverter;
    }

    public ITextNumberReplaceStrategy CreateStrategy(string language)
    {
        switch (language.ToLower())
        {
            case "turkish":
                return new TurkishTextNumberReplaceStrategy(_turkishHelper, _textToNumberConverter);
            // Add other languages as needed...
            default:
                throw new NotSupportedException($"Language '{language}' is not supported.");
        }
    }
}