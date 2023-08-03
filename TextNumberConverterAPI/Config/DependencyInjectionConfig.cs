using Microsoft.OpenApi.Models;
using TextNumberConverterAPI.Abstractions;
using TextNumberConverterAPI.Factories;
using TextNumberConverterAPI.Helpers;
using TextNumberConverterAPI.Repositories;
using TextNumberConverterAPI.Services;
using TextNumberConverterAPI.Strategies;

namespace TextNumberConverterAPI.Config;

public static class DependencyInjectionConfig
{
    public static void ConfigureServices(IServiceCollection services)
    {
        // Add services to the container.
        services.AddControllers();
        services.AddSingleton<ITurkishNumbersRegexHelper, TurkishNumbersRegexHelper>();
        services.AddTransient<ITextToNumberConverter, TextToNumberConverter>();
        services.AddTransient<ITextNumberReplacer, TextNumberReplacer>();
        services.AddTransient<ITextNumberReplaceStrategy, TurkishTextNumberReplaceStrategy>();
        services.AddSingleton<ITextNumberReplaceStrategyFactory, TextNumberReplaceStrategyFactory>();
        services.AddTransient<IConverterRepository, ConverterRepository>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {Title = "Text to number converter API", Version = "v1"});
        });
    }
}