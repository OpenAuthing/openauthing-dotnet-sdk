using BeniceSoft.OpenAuthing.AspNetCore.Authorization;
using BeniceSoft.OpenAuthing.AspNetCore.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BeniceSoft.OpenAuthing.AspNetCore;

public static class ServiceCollectionExtensions
{
    public static OpenAuthingBuilder AddOpenAuthing(this IServiceCollection services, string permissionSpaceId)
    {
        services.AddOptions();
        services.AddSingleton<IAuthorizationHandler, PermissionRequirementHandler>();
        services.TryAdd(ServiceDescriptor.Transient<IPermissionChecker, OpenAuthingPermissionChecker>());

        var builder = new OpenAuthingBuilder(services, permissionSpaceId);
        builder.AddCurrentUserPermissionProvider<NullCurrentUserPermissionProvider>();
        
        return builder;
    }

    public static IServiceCollection AddOpenAuthing(this IServiceCollection services, string permissionSpaceId,
        Action<OpenAuthingBuilder> configuration)
    {
        configuration(services.AddOpenAuthing(permissionSpaceId));
        return services;
    }
}