using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace OngProject.Middleware
{
    public class PersistActionsRestrictionsMiddleware
    {
        private readonly List<string> _restrictedRestMethods;
        private readonly List<string> _authorizedRoles;
        private readonly RequestDelegate _next;
        private readonly string _roleUser;

        public PersistActionsRestrictionsMiddleware(RequestDelegate next)
        {
            _next = next;

            _authorizedRoles = new List<string> { "Administrador" };
            _restrictedRestMethods = new List<string> { "POST", "PUT", "PATCH", "DELETE" };
            _roleUser = "Usuario";
        }

        public async Task InvokeAsync(HttpContext context)
        { 
            var isRestrictedAction = _restrictedRestMethods.Any(x => x == context.Request.Method);
            var isAuthRoute = context.Request.Path.StartsWithSegments("/Auth");
            var canAccessToRoute = isAuthRoute || !isRestrictedAction || userHasAuthorizedRole(context);

            if(await Ownership(context, "/User", "DELETE"))
                return;
            
            if (!canAccessToRoute)
                await context.Response.WriteAsync($"You don't have authorization for this request.");

            else
                await _next.Invoke(context);
        }

        private bool userHasAuthorizedRole(HttpContext context)
        {
            var identity = context.User.Identity as ClaimsIdentity;

            if (identity == null || !identity.Claims.Any())
                return false;

            var userRole = identity.Claims.FirstOrDefault(x => x.Type == identity.RoleClaimType);
            
            return _authorizedRoles.Any(x => x == userRole.Value);
        }

        private async Task<bool> Ownership(HttpContext context, string route, string method)
        {
            var RouteProtected = context.Request.Path.StartsWithSegments(route) && context.Request.Method == method;

            if (RouteProtected)
            {
                var canAccessToRoute = userHasAuthorizedRole(context) || userHasRole(context) && compareId(context);

                if (canAccessToRoute)
                {
                    await _next.Invoke(context);
                    return true;
                }
                if (!canAccessToRoute)
                {
                    context.Response.StatusCode = 403;
                    return true;
                }
            }
            return false;
        }
        private string getUserId(HttpContext context)
        {
            var identity = context.User.Identity as ClaimsIdentity;
            //var userId = context.User.Claims.ToArray()[2].Value;
            var userId = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            return userId;
        }

        private bool compareId(HttpContext context)
        {
            var idParameter = context.Request.RouteValues["id"].ToString();
            if (getUserId(context) == idParameter)
                return true;
            else return false;
        }

        private bool userHasRole(HttpContext context)
        {
            var identity = context.User.Identity as ClaimsIdentity;

            if (identity == null || !identity.Claims.Any())
                return false;

            var userRole = identity.Claims.FirstOrDefault(x => x.Type == identity.RoleClaimType);

            if (userRole.Value == _roleUser)
                return true;
            return false;
        }
    }

    public static class UsePersistActionsRestrictionsExtension
    {
        public static void UsePersistActionsRestrictions(this IApplicationBuilder app)
            => app.UseMiddleware<PersistActionsRestrictionsMiddleware>();
    }
}
