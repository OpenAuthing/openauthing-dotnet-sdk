using BeniceSoft.OpenAuthing.AspNetCore.Authorization;
using BeniceSoft.OpenAuthing.AspNetCore.Authorization.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace BeniceSoft.OpenAuthing.AspNetCore;

public static class ServiceCollectionExtensions
{
    public static OpenAuthingBuilder AddOpenAuthing(this IServiceCollection services, Action<OpenAuthingOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));
        ArgumentNullException.ThrowIfNull(configure, nameof(configure));

        var builder = new OpenAuthingBuilder(services);

        builder.Services.AddOptions();
        builder.Services.AddSingleton<IAuthorizationHandler, PermissionRequirementHandler>();
        builder.Services.AddTransient<IPermissionChecker, PermissionChecker>();
        builder.Services.Configure(configure);
        builder.Services.AddOptions<OpenAuthingOptions>().Validate(x =>
        {
            x.Validate();
            return true;
        });

        builder.AddCurrentUserPermissionProvider<NullCurrentUserPermissionProvider>();

        return builder;
    }

    public static OpenAuthingBuilder AddOpenAuthing(this IServiceCollection services, string permissionSpaceId)
    {
        return services.AddOpenAuthing(options =>
        {
            options.PermissionSpaceId = permissionSpaceId;
        });
    }

    public static IServiceCollection AddOpenAuthing(this IServiceCollection services, string permissionSpaceId,
        Action<OpenAuthingBuilder> configuration)
    {
        configuration(services.AddOpenAuthing(permissionSpaceId));
        return services;
    }
}