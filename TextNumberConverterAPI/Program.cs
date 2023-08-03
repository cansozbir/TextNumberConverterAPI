using TextNumberConverterAPI.Config;

var builder = WebApplication.CreateBuilder(args);

DependencyInjectionConfig.ConfigureServices(builder.Services);
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();