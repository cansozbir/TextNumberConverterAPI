using TextNumberConverterAPI.Strategies;

namespace TextNumberConverterAPI.Services;

public class TextNumberReplacer : ITextNumberReplacer
{
    private readonly ITextNumberReplaceStrategy _strategy;

    public TextNumberReplacer(ITextNumberReplaceStrategy strategy)
    {
        _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
    }

    public string ReplaceAll(string text)
    {
        return _strategy.ReplaceAll(text);
    }
}