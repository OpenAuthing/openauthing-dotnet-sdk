namespace BeniceSoft.OpenAuthing.AspNetCore.Authorization.Permissions;

public interface ICurrentUserPermissionProvider
{
    Task<ICurrentUserPermission> GetAsync(Guid userId, string permissionSpaceId);
}