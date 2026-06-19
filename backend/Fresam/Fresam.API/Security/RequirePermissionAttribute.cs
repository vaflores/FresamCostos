using Microsoft.AspNetCore.Authorization;

namespace Fresam.API.Security;

public class RequirePermissionAttribute : AuthorizeAttribute
{
    public RequirePermissionAttribute(string permission)
    {
        Policy = $"Permission:{permission}";
    }
}
