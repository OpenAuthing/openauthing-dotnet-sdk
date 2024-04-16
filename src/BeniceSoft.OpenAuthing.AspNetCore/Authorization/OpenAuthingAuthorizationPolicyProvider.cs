using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace BeniceSoft.OpenAuthing.AspNetCore.Authorization;

public class OpenAuthingAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
{
    public OpenAuthingAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : base(options)
    {
    }

    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        var policy = await base.GetPolicyAsync(policyName);
        if (policy is not null) return policy;

        var permission = policyName.StartsWith("P:") ? policyName.TrimStart("P:".ToCharArray()) : null;
        if (!string.IsNullOrWhiteSpace(permission))
        {
            //TODO: Optimize & Cache!
            var policyBuilder = new AuthorizationPolicyBuilder([]);
            policyBuilder.Requirements.Add(new PermissionRequirement(permission));
            return policyBuilder.Build();
        }

        return null;
    }
}