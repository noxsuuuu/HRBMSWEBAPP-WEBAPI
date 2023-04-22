using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using HRBMSWEBAPP.Repository;
using Microsoft.EntityFrameworkCore;
using HRBMSWEBAPP.Data;

namespace HRBMSWEBAPP.Service
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly HRBMSDBCONTEXT _context;

        public UserService(IHttpContextAccessor httpContext,HRBMSDBCONTEXT context)
        {
            _httpContext = httpContext;
            _context = context;
        }
        public string GetUserId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        }
        public string GetUserFirstName()
        {
            var userId = _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    return user.Full_Name;
                }
            }
            return null;
        }
        public bool isAuthenticated()
        {
            return _httpContext.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
