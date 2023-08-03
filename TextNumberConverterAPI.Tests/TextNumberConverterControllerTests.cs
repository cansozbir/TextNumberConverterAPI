using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TextNumberConverterAPI.Abstractions;
using TextNumberConverterAPI.Controllers;
using TextNumberConverterAPI.DTOs;
using Xunit;

namespace TextNumberConverterAPI.Tests;

public class TextNumberConverterControllerTests
{
    private readonly TextNumberConverterController _controller;
    private readonly Mock<ILogger<TextNumberConverterController>> _mockLogger;
    private readonly Mock<IConverterRepository> _mockRepository;

    public TextNumberConverterControllerTests()
    {
        _mockRepository = new Mock<IConverterRepository>();
        _mockLogger = new Mock<ILogger<TextNumberConverterController>>();
        _controller = new TextNumberConverterController(_mockRepository.Object, _mockLogger.Object);
    }

    [Fact]
    public void Post_ValidInput_ShouldReturnOkResult()
    {
        // Arrange
        var request = new TextToNumberConverterRequest("beş");
        _mockRepository.Setup(repo => repo.ConvertTextToNumber(It.IsAny<string>())).Returns("5");

        // Act
        var result = _controller.Post(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<TextToNumberConverterResponse>(okResult.Value);
        Assert.Equal("5", response.Output);
    }

    [Fact]
    public void Post_InvalidInput_ShouldReturnBadRequest()
    {
        // Arrange
        var request = new TextToNumberConverterRequest("");
        _mockRepository.Setup(repo => repo.ConvertTextToNumber(It.IsAny<string>())).Returns("5");

        // Act
        var result = _controller.Post(request);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public void Post_InvalidInput_ShouldLogWarning()
    {
        // Arrange
        var request = new TextToNumberConverterRequest("");
        _mockRepository.Setup(repo => repo.ConvertTextToNumber(It.IsAny<string>())).Returns("5");

        // Act
        var result = _controller.Post(request);

        // Assert
        _mockLogger.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => true),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)));
    }
}