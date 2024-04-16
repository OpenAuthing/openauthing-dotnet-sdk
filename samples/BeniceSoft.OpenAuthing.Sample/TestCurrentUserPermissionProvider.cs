using System.Collections.Immutable;
using BeniceSoft.OpenAuthing.AspNetCore.Authorization.Permissions;

namespace BeniceSoft.OpenAuthing.Sample;

public class TestCurrentUserPermissionProvider : ICurrentUserPermissionProvider
{
    public Task<ICurrentUserPermission> GetAsync(Guid userId, string permissionSpaceId)
    {
        string[] permissionKeys = ["test"];
        return Task.FromResult<ICurrentUserPermission>(new CurrentUserPermission()
        {
            PermissionKeys = permissionKeys.ToImmutableHashSet()
        });
    }
}