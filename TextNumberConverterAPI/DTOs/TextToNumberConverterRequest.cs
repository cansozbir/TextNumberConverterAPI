namespace TextNumberConverterAPI.DTOs;

public class TextToNumberConverterRequest
{
    public TextToNumberConverterRequest(string userText)
    {
        UserText = userText;
    }

    public string UserText { get; private set; }
}