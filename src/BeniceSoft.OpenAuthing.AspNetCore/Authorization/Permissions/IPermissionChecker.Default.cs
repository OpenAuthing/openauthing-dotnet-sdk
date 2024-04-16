using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace BeniceSoft.OpenAuthing.AspNetCore.Authorization.Permissions;

public class PermissionChecker : IPermissionChecker
{
    private readonly OpenAuthingOptions _options;
    private readonly ICurrentUserPermissionProvider _currentUserPermissionProvider;

    public PermissionChecker(
        IOptions<OpenAuthingOptions> options,
        ICurrentUserPermissionProvider currentUserPermissionProvider)
    {
        _options = options.Value ?? throw new ArgumentNullException(nameof(options));
        _currentUserPermissionProvider = currentUserPermissionProvider;
    }

    public async Task<bool> IsGrantedAsync(ClaimsPrincipal? claimsPrincipal, string name)
    {
        var userId = claimsPrincipal?.FindUserId();
        if (userId.HasValue == false) return false;

        var permission = await _currentUserPermissionProvider.GetAsync(userId.Value, _options.PermissionSpaceId);

        return permission.PermissionKeys.Contains(name);
    }

    public async Task<MultiplePermissionGrantResult> IsGrantedAsync(ClaimsPrincipal? claimsPrincipal, string[] names)
    {
        var result = new MultiplePermissionGrantResult();
        foreach (var name in names)
        {
            var isGrant = await IsGrantedAsync(claimsPrincipal, name);
            result.Result.Add(name, isGrant ? PermissionGrantResult.Granted : PermissionGrantResult.Prohibited);
        }

        return result;
    }
}