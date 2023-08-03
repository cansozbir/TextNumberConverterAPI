using Microsoft.AspNetCore.Mvc;
using TextNumberConverterAPI.Abstractions;
using TextNumberConverterAPI.DTOs;

namespace TextNumberConverterAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TextNumberConverterController : ControllerBase
{
    private readonly ILogger<TextNumberConverterController> _logger;
    private readonly IConverterRepository _repository;

    public TextNumberConverterController(IConverterRepository repository, ILogger<TextNumberConverterController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <summary>
    ///     Convert text containing numbers to numeric representation.
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     POST /api/TextNumberConverter
    ///     {
    ///     "userText": "Elli altı bin lira kredi alıp üç yılda geri ödeyeceğim."
    ///     }
    /// </remarks>
    /// <param name="textToNumberConverterRequest" example="Elli altı bin lira kredi alıp üç yılda geri ödeyeceğim">
    ///     The text to
    ///     convert.
    /// </param>
    /// <returns>Replaces all numbers found on input by their digit equivalent and returns the result string.</returns>
    /// <response code="200">
    ///     Successfully replaces all numbers found on input by their digit equivalent and returns the result
    ///     string.
    /// </response>
    /// <response code="400">If the request is invalid.</response>
    [HttpPost]
    [ProducesResponseType(typeof(TextToNumberConverterResponse), 200)]
    [ProducesResponseType(400)]
    public IActionResult Post(TextToNumberConverterRequest textToNumberConverterRequest)
    {
        if (string.IsNullOrEmpty(textToNumberConverterRequest.UserText))
        {
            _logger.LogWarning("Invalid request. UserText is empty or null.");
            return BadRequest();
        }

        _logger.LogInformation("Converting text to number: {UserText}", textToNumberConverterRequest.UserText);
        var output = _repository.ConvertTextToNumber(textToNumberConverterRequest.UserText);
        _logger.LogInformation("Converted text to number: {UserText}", output);

        return Ok(new TextToNumberConverterResponse(output));
    }
}