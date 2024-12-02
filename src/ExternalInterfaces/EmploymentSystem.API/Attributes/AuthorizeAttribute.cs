using EmploymentSystem.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EmploymentSystem.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly List<string> _roles;

        public AuthorizeAttribute(params string[] Roles)
        {
            _roles = Roles.ToList();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>();
            if (allowAnonymous.Any()) return;

            var user = context.HttpContext.User;
            var userId = user.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            if (user != null && _roles.Any())
            {
                var db = context.HttpContext.RequestServices.GetService<ApplicationDbContext>();
                var userRoles = (from ur in db.UserRoles
                                 join r in db.Roles on ur.RoleId equals r.Id
                                 join u in db.Users on ur.UserId equals u.Id
                                 where u.Id == userId
                                 select new
                                 {
                                     r.Name
                                 }).ToList();

                var isAuthorized = false;
                foreach (var role in userRoles)
                {
                    if (_roles.Contains(role.Name))
                        isAuthorized = true;
                }
                if (isAuthorized) return;
            }

            context.Result = new UnauthorizedResult();
        }
    }
}
