using BeniceSoft.OpenAuthing.AspNetCore.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace BeniceSoft.OpenAuthing.AspNetCore.Authorization;

public class PermissionRequirementHandler(IPermissionChecker permissionChecker) : AuthorizationHandler<PermissionRequirement>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        if (await permissionChecker.IsGrantedAsync(context.User, requirement.PermissionKey))
        {
            context.Succeed(requirement);
        }
    }
}