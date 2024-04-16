using System.Collections.Immutable;

namespace BeniceSoft.OpenAuthing.AspNetCore.Authorization.Permissions;

public interface ICurrentUserPermission
{
    public ImmutableHashSet<string> PermissionKeys { get; set; }
}