using System.Security.Claims;

namespace BeniceSoft.OpenAuthing.AspNetCore;

public static class ClaimsPrincipalExtensions
{
    public static Guid? FindUserId(this ClaimsPrincipal principal)
    {
        ArgumentNullException.ThrowIfNull(principal, nameof(principal));

        var userIdOrNull = principal.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        if (userIdOrNull == null || string.IsNullOrWhiteSpace(userIdOrNull.Value))
        {
            return null;
        }

        if (Guid.TryParse(userIdOrNull.Value, out Guid guid))
        {
            return guid;
        }

        return null;
    }
}