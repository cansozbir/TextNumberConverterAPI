using TextNumberConverterAPI.Helpers;
using TextNumberConverterAPI.Repositories;
using TextNumberConverterAPI.Services;
using TextNumberConverterAPI.Strategies;
using Xunit;

namespace TextNumberConverterAPI.Tests;

public class ConverterRepositoryTests
{
    [Theory]
    [InlineData("Yüz bin lira kredi kullanmak istiyorum", "100000 lira kredi kullanmak istiyorum")]
    [InlineData("Bugün yirmi sekiz yaşına girdim", "Bugün 28 yaşına girdim")]
    [InlineData("Elli altı bin lira kredi alıp üç yılda geri ödeyeceğim",
        "56000 lira kredi alıp 3 yılda geri ödeyeceğim")]
    [InlineData("Seksen yedi bin iki yüz on altı lira borcum var", "87216 lira borcum var")]
    [InlineData("Bin yirmi dört lira eksiğim kaldı", "1024 lira eksiğim kaldı")]
    [InlineData("Yarın saat onaltıda geleceğim", "Yarın saat 16da geleceğim")]
    [InlineData("Dokuzyüzelli beş lira fiyatı var", "955 lira fiyatı var")]
    public void ConvertTextToNumber_ValidInput_ShouldReturnExpectedOutput(string input, string expectedOutput)
    {
        // Arrange
        var strategy = new TurkishTextNumberReplaceStrategy(new TurkishNumbersRegexHelper(),
            new TextToNumberConverter(new TurkishNumbersRegexHelper()));
        var textNumberReplacer = new TextNumberReplacer(strategy);
        var converterRepository = new ConverterRepository(textNumberReplacer);

        // Act
        var result = converterRepository.ConvertTextToNumber(input);

        // Assert
        Assert.Equal(expectedOutput, result);
    }


    [Theory]
    [InlineData("100 bin lira kredi kullanmak istiyorum", "100000 lira kredi kullanmak istiyorum")]
    [InlineData("Bugün yirmi 8 yaşına girdim", "Bugün 28 yaşına girdim")]
    [InlineData("Elli 6 bin lira kredi alıp üç yılda geri ödeyeceğim", "56000 lira kredi alıp 3 yılda geri ödeyeceğim")]
    [InlineData("Seksen 7 bin iki 100 on altı lira borcum var", "87216 lira borcum var")]
    [InlineData("Bin 20 dört lira eksiğim kaldı", "1024 lira eksiğim kaldı")]
    [InlineData("Yarın saat 10altıda geleceğim", "Yarın saat 16da geleceğim")]
    [InlineData("9yüz50beş lira fiyatı var", "955 lira fiyatı var")]
    public void ConvertTextToNumber_ValidInput_ShouldReturnExpectedOutput_Bonus(string input, string expectedOutput)
    {
        // Arrange
        var strategy = new TurkishTextNumberReplaceStrategy(new TurkishNumbersRegexHelper(),
            new TextToNumberConverter(new TurkishNumbersRegexHelper()));
        var textNumberReplacer = new TextNumberReplacer(strategy);
        var converterRepository = new ConverterRepository(textNumberReplacer);

        // Act
        var result = converterRepository.ConvertTextToNumber(input);

        // Assert
        Assert.Equal(expectedOutput, result);
    }
}