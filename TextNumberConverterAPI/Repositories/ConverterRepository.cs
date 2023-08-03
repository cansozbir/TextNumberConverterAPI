using TextNumberConverterAPI.Abstractions;
using TextNumberConverterAPI.Services;

namespace TextNumberConverterAPI.Repositories;

public class ConverterRepository : IConverterRepository
{
    private readonly ITextNumberReplacer _textNumberReplacer;

    public ConverterRepository(ITextNumberReplacer textNumberReplacer)
    {
        _textNumberReplacer = textNumberReplacer;
    }

    public string ConvertTextToNumber(string text)
    {
        return _textNumberReplacer.ReplaceAll(text);
    }
}