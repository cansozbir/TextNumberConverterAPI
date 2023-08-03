namespace TextNumberConverterAPI.DTOs;

public class TextToNumberConverterResponse
{
    public TextToNumberConverterResponse(string output)
    {
        Output = output;
    }

    public string Output { get; private set; }
}