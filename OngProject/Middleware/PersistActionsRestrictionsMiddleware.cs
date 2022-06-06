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

        public PersistActionsRestrictionsMiddleware(RequestDelegate next)
        {
            _next = next;

            _authorizedRoles = new List<string> { "Administrador" };
            _restrictedRestMethods = new List<string> { "POST", "PUT", "PATCH", "DELETE" };
        }

        public async Task InvokeAsync(HttpContext context)
        { 
            var isRestrictedAction = _restrictedRestMethods.Any(x => x == context.Request.Method);
            var isAuthRoute = context.Request.Path.StartsWithSegments("/Auth");

            var canAccessToRoute = isAuthRoute || !isRestrictedAction || userHasAuthorizedRole(context);

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
    }

    public static class UsePersistActionsRestrictionsExtension
    {
        public static void UsePersistActionsRestrictions(this IApplicationBuilder app)
            => app.UseMiddleware<PersistActionsRestrictionsMiddleware>();
    }
}
