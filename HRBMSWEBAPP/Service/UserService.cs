using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using HRBMSWEBAPP.Repository;

namespace HRBMSWEBAPP.Service
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;
        public UserService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public string GetUserId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        }

        public bool isAuthenticated()
        {
            return _httpContext.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
