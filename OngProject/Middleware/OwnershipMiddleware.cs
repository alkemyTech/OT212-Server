using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace OngProject.Middleware
{
    public class OwnershipMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly List<string> _authorizedRoles;
        private readonly string _route;
        private readonly string _method;

        public OwnershipMiddleware(RequestDelegate next)
        {
            _next = next;
            _authorizedRoles = new List<string> { "Administrador"};
            _route = "/User";
            _method = "DELETE";
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var routeProtected = context.Request.Path.StartsWithSegments(_route) && context.Request.Method == _method;
            var canAccessToRoute = userHasAuthorizedRole(context) || compareId(context);

            if (routeProtected && !canAccessToRoute)
                    context.Response.StatusCode = 403;
            else 
                await _next.Invoke(context);
        }

        private bool compareId(HttpContext context)
        {
            var identity = context.User.Identity as ClaimsIdentity;

            if (identity == null || !identity.Claims.Any())
                return false;

            var userId = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var idFromParameter = context.Request.RouteValues["id"];

            return userId == idFromParameter?.ToString();
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

    public static class UseOwnerwhipRestrictionsExtension
    {
        public static void UseOwnershipRestrictions(this IApplicationBuilder app)
            => app.UseMiddleware<OwnershipMiddleware>();
    }
}
