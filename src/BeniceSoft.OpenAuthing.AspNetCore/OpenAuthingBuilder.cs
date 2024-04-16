using Microsoft.Extensions.DependencyInjection;

namespace BeniceSoft.OpenAuthing.AspNetCore;

public class OpenAuthingBuilder
{
    public IServiceCollection Services { get; }

    public OpenAuthingBuilder(IServiceCollection services)
    {
        Services = services;
    }
}