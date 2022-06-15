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
        private List<Permission> permissions;
        private readonly RequestDelegate _next;

        public PersistActionsRestrictionsMiddleware(RequestDelegate next)
        {
            _next = next;
            _restrictedRestMethods = new List<string> { "POST", "PUT", "PATCH", "DELETE" };
            permissions = new List<Permission>();

            ConfigurePermissions();
        }

        private void ConfigurePermissions()
        {
            permissions.Add(new Permission { Role = "Administrador" });
            permissions.Add(new Permission { Route = "/Auth" });
            permissions.Add(new Permission { Route = "/User", Method = "DELETE" });
            permissions.Add(new Permission { Route = "/Comments" });
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var isRestrictedAction = _restrictedRestMethods.Any(x => x == context.Request.Method);
            var canAccessToRoute = !isRestrictedAction || HasPermissions(context);

            if (!canAccessToRoute)
                context.Response.StatusCode = 403;

            else
                await _next.Invoke(context);
        }

        private bool HasPermissions(HttpContext context)
        {
            var lstPermission = new List<Permission>();
            var route = context.Request.Path;
            var method = context.Request.Method;
            var role = "";

            var identity = context.User.Identity as ClaimsIdentity;

            if (identity != null && identity.Claims.Any())
                role = identity.Claims.FirstOrDefault(x => x.Type == identity.RoleClaimType).Value;


            if (!string.IsNullOrEmpty(role))
            {
                if (permissions.Any(p => p.Role == role && string.IsNullOrEmpty(p.Route)))
                    return true;

                lstPermission = permissions.Where(p => p.Role == role && route.StartsWithSegments(p.Route)).ToList();

                if (lstPermission.Any(p => p.Method == method)
                    || lstPermission.Any(p => string.IsNullOrEmpty(p.Method)))
                    return true;
            }

            lstPermission = permissions.Where(p => !string.IsNullOrEmpty(p.Route) && route.StartsWithSegments(p.Route)).ToList();

            return lstPermission.Any(p => p.Method == method)
                || lstPermission.Any(p => string.IsNullOrEmpty(p.Method));
        }

        internal class Permission
        {
            public string Role { get; set; }

            public string Route { get; set; }

            public string Method { get; set; }
        }
    }

    public static class UsePersistActionsRestrictionsExtension
    {
        public static void UsePersistActionsRestrictions(this IApplicationBuilder app)
            => app.UseMiddleware<PersistActionsRestrictionsMiddleware>();
    }
}
