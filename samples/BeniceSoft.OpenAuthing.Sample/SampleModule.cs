using BeniceSoft.Abp.AspNetCore;
using BeniceSoft.OpenAuthing.AspNetCore;
using BeniceSoft.OpenAuthing.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace BeniceSoft.OpenAuthing.Sample;

[DependsOn(
    typeof(BeniceSoftAbpAspNetCoreModule)
)]
public class SampleModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        context.Services.AddEndpointsApiExplorer();
        context.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Scheme = "Bearer",
                Description = "Specify the authorization token.",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                    },
                    Array.Empty<string>()
                },
            });
        });

        context.Services.AddOpenAuthing("sdfsdf")
            .AddAuthentication(options =>
            {
                options.Authority = "http://localhost:5129/";
                options.TokenValidationParameters.ValidIssuers = ["http://localhost:5129/"];
            })
            .AddAuthorization(builder => { builder.AddCurrentUserPermissionProvider<TestCurrentUserPermissionProvider>(); });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();

        app.UseStaticFiles();
        app.UseRouting();

        app.UseOpenAuthing();

        app.UseSwagger();
        app.UseSwaggerUI();

        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        app.UseConfiguredEndpoints(endpoints =>
        {
            endpoints.MapGet("/weatherforecast", () =>
                {
                    var forecast = Enumerable.Range(1, 5).Select(index =>
                            new WeatherForecast
                            (
                                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                                Random.Shared.Next(-20, 55),
                                summaries[Random.Shared.Next(summaries.Length)]
                            ))
                        .ToArray();
                    return forecast;
                })
                .RequireAuthorization("P:test")
                .WithName("GetWeatherForecast")
                .WithOpenApi();
        });
    }
}