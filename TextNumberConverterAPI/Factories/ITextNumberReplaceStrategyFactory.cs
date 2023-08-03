using TextNumberConverterAPI.Strategies;

namespace TextNumberConverterAPI.Factories;

public interface ITextNumberReplaceStrategyFactory
{
    ITextNumberReplaceStrategy CreateStrategy(string language);
}