using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SelfHosted.Controller.V1.Authorizations;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = (Service.Users.Domain.User) context.HttpContext.Items["User"];
        if (user == null)
            // not logged in
        {
            context.Result = new JsonResult(new {message = "Unauthorized"})
                {StatusCode = StatusCodes.Status401Unauthorized};
        }
    }
}