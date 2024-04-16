using Microsoft.Extensions.DependencyInjection;

namespace BeniceSoft.OpenAuthing.AspNetCore;

public class OpenAuthingBuilder
{
    public IServiceCollection Services { get; }

    public OpenAuthingBuilder(IServiceCollection services, string permissionSpaceId)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));
        ArgumentException.ThrowIfNullOrWhiteSpace(permissionSpaceId, nameof(permissionSpaceId));

        Services = services;

        Services.Configure<OpenAuthingOptions>(opt => { opt.PermissionSpaceId = permissionSpaceId; });
    }
}