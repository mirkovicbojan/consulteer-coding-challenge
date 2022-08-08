
using MainAPI.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace MainAPI.Handlers
{
    public class CanEditRolesHandler : AuthorizationHandler<IsAdminRequirement>
    {
        public readonly IHttpContextAccessor _accessor;

        public CanEditRolesHandler(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        IsAdminRequirement requirement)
        {
            var claimValue = _accessor.HttpContext.User.FindFirst("isAdmin").Value;
            if (claimValue == "True")
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}