using Microsoft.AspNetCore.Authorization;

namespace Fresam.API.Security;

public class PermissionAuthorizationHandler
    : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        var tienePermiso =
            context.User.Claims.Any(c =>
                c.Type == "permission" &&
                c.Value == requirement.Permission);

        if (tienePermiso)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
