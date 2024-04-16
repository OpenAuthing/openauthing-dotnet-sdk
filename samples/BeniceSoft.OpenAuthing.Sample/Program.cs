using BeniceSoft.OpenAuthing.Sample;

var builder = WebApplication.CreateBuilder(args);
await builder.AddApplicationAsync<SampleModule>();
var app = builder.Build();

await app.InitializeApplicationAsync();

await app.RunAsync();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
