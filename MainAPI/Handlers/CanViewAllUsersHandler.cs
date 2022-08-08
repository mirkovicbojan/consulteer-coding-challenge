using MainAPI.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace MainAPI.Handlers
{
    public class CanViewAllUsersHandler : AuthorizationHandler<CanViewAllUsersRequirement>
    {
        public readonly IHttpContextAccessor _accessor;

        public CanViewAllUsersHandler(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        CanViewAllUsersRequirement requirement)
        {
            var claimValue = _accessor.HttpContext.User.FindFirst("CanViewAllUsers").Value;
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