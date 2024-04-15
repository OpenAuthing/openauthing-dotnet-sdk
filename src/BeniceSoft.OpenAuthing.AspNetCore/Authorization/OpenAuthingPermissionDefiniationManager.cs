using Volo.Abp.Authorization.Permissions;

namespace BeniceSoft.OpenAuthing.AspNetCore.Authorization;

public class OpenAuthingPermissionDefinitionManager : IPermissionDefinitionManager
{
    public Task<PermissionDefinition> GetAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<PermissionDefinition?> GetOrNullAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<PermissionDefinition>> GetPermissionsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<PermissionGroupDefinition>> GetGroupsAsync()
    {
        throw new NotImplementedException();
    }
}