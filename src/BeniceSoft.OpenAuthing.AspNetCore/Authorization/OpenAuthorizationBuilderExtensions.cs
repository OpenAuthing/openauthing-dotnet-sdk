using BeniceSoft.OpenAuthing.AspNetCore.Permissions;
using Microsoft.Extensions.DependencyInjection;

namespace BeniceSoft.OpenAuthing.AspNetCore.Authorization;

public static class OpenAuthingAuthorizationBuilderExtensions
{
    public static OpenAuthingAuthorizationBuilder AddCurrentUserPermissionProvider<T>(this OpenAuthingAuthorizationBuilder builder,
        ServiceLifetime lifetime = ServiceLifetime.Transient)
        where T : class, ICurrentUserPermissionProvider, new()
    {
        builder.OpenAuthingBuilder.AddCurrentUserPermissionProvider<T>(lifetime);
        return builder;
    }
}