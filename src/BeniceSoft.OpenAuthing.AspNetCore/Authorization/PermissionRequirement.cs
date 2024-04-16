using Microsoft.AspNetCore.Authorization;

namespace BeniceSoft.OpenAuthing.AspNetCore.Authorization;

public class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionRequirement(string permissionKey)
    {
        PermissionKey = permissionKey;
    }

    public string PermissionKey { get; private set; }
}