using Microsoft.Extensions.DependencyInjection;

namespace BeniceSoft.OpenAuthing.AspNetCore.Authorization;

public class OpenAuthingAuthorizationBuilder
{
    public OpenAuthingBuilder OpenAuthingBuilder {get;}
    public IServiceCollection Services {get;}
    public OpenAuthingAuthorizationBuilder(IServiceCollection services, OpenAuthingBuilder builder)
    {
        OpenAuthingBuilder = builder;
        Services = services;
    }
}