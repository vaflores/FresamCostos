using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Fresam.API.Security;

public class PermissionPolicyProvider : DefaultAuthorizationPolicyProvider
{
    public PermissionPolicyProvider(IOptions<AuthorizationOptions> options) : base(options) 
    { 
    }

    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        if (policyName.StartsWith("Permission:"))
        {
            var permission = policyName.Substring("Permission:".Length);

            var policy = new AuthorizationPolicyBuilder()
                    .AddRequirements(new PermissionRequirement(permission))
                    .Build();

            return policy;
        }

        return await base.GetPolicyAsync(policyName);
    }
}
