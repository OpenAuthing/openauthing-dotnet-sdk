using System.Collections.Immutable;

namespace BeniceSoft.OpenAuthing.AspNetCore.Permissions;

public interface ICurrentUserPermission
{
    public ImmutableHashSet<string> PermissionKeys { get; set; }
}