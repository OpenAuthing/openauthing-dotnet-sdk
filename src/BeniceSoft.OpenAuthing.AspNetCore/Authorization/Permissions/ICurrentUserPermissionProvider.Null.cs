namespace BeniceSoft.OpenAuthing.AspNetCore.Authorization.Permissions;

public class NullCurrentUserPermissionProvider : ICurrentUserPermissionProvider
{
    public Task<ICurrentUserPermission> GetAsync(Guid userId, string permissionSpaceId)
    {
        return Task.FromResult<ICurrentUserPermission>(new CurrentUserPermission());
    }
}