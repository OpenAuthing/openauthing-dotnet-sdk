using BeniceSoft.OpenAuthing.AspNetCore.Authorization.Permissions;
using Microsoft.Extensions.DependencyInjection;

namespace BeniceSoft.OpenAuthing.AspNetCore.Authorization;

public static class OpenAuthingAuthorizationBuilderExtensions
{
    public static OpenAuthingAuthorizationBuilder AddCurrentUserPermissionProvider<T>(
        this OpenAuthingAuthorizationBuilder builder, ServiceLifetime lifetime = ServiceLifetime.Transient)
        where T : class, ICurrentUserPermissionProvider
    {
        builder.OpenAuthingBuilder.AddCurrentUserPermissionProvider<T>(lifetime);
        return builder;
    }

    public static OpenAuthingAuthorizationBuilder AddHttpClientCurrentUserPermissionProvider(this OpenAuthingAuthorizationBuilder builder)
    {
        builder.Services.AddHttpClient<HttpClientCurrentUserPermissionProvider>();
        builder.AddCurrentUserPermissionProvider<HttpClientCurrentUserPermissionProvider>(ServiceLifetime.Transient);

        return builder;
    }
}