using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace BeniceSoft.OpenAuthing.AspNetCore.Authorization;

public class OpenAuthingAuthorizationBuilder
{
    public IServiceCollection Services { get; }

    public string PermissionSpaceId { get; }

    public OpenAuthingAuthorizationBuilder(IServiceCollection services, string permissionSpaceId)
    {
        Check.NotNull(services, nameof(services));
        Check.NotNullOrWhiteSpace(permissionSpaceId, nameof(permissionSpaceId));
        
        Services = services;
        PermissionSpaceId = permissionSpaceId;
    }
}