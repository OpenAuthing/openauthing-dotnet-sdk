namespace BeniceSoft.OpenAuthing.AspNetCore.Permissions;

public interface ICurrentUserPermissionProvider
{
    Task<ICurrentUserPermission> GetAsync(Guid userId, string permissionSpaceId);
}