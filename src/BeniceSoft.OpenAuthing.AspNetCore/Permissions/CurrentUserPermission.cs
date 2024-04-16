using System.Collections.Immutable;

namespace BeniceSoft.OpenAuthing.AspNetCore.Permissions;

public class CurrentUserPermission : ICurrentUserPermission
{
    public ImmutableHashSet<string> PermissionKeys { get; set; } = ImmutableHashSet<string>.Empty;
}