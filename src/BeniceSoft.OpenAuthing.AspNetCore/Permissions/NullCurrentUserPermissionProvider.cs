namespace BeniceSoft.OpenAuthing.AspNetCore.Permissions;

public class NullCurrentUserPermissionProvider : ICurrentUserPermissionProvider
{
    public Task<ICurrentUserPermission> GetAsync(Guid userId, string permissionSpaceId)
    {
        return Task.FromResult<ICurrentUserPermission>(new CurrentUserPermission());
    }
}