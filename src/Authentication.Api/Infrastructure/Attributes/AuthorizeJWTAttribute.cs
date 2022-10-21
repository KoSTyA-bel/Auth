using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Infrastructure.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeJWTAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var account = context.HttpContext.Items["User"];
        if (account == null)
        {
            context.Result = new JsonResult(new { message = "Unauthorized" }) 
            { 
                StatusCode = StatusCodes.Status401Unauthorized 
            };
        }
    }
}
