using HRBMSWEBAPI.DTO;
using HRBMSWEBAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace HRBMSWEBAPI.Repository
{
    public interface IAccountRepository
    {
        Task<ApplicationUser> SignUpUserAsync(ApplicationUser user, string password);
        Task<SignInResult> SignInUserAsync(LoginDTO loginDTO);
        Task<ApplicationUser> FindUserByEmailAsync(string email);
    }
}
