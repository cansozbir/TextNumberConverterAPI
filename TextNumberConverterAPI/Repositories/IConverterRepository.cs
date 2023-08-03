namespace TextNumberConverterAPI.Abstractions;

public interface IConverterRepository
{
    string ConvertTextToNumber(string text);
}