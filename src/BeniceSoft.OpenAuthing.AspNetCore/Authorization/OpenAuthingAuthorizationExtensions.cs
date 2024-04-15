using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.Authorization.Permissions;

namespace BeniceSoft.OpenAuthing.AspNetCore.Authorization;

public static class OpenAuthingAuthorizationExtensions
{
    public static OpenAuthingAuthorizationBuilder AddOpenAuthingAuthorization(this IServiceCollection services, string permissionSpaceId,
        Action<OpenAuthingAuthorizationBuilder>? configure = null)
    {
        services.AddAuthorization();
        services.Replace(ServiceDescriptor.Transient<IPermissionDefinitionManager, OpenAuthingPermissionDefinitionManager>());

        var builder = new OpenAuthingAuthorizationBuilder(services, permissionSpaceId);
        configure?.Invoke(builder);

        return builder;
    }
}