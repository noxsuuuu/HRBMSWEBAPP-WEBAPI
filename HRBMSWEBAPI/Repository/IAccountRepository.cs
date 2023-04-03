using HRBMSWEBAPI.Models;
using Microsoft.AspNetCore.Identity;
using HRBMSWEBAPI.DTO;

namespace HRBMSWEBAPI.Repository
{
    public interface IAccountRepository
    {
        Task<User> SignUpUserAsync(User user, string password);
        Task<SignInResult> SignInUserAsync(LoginDTO loginDTO);
        Task<User> FindUserByEmailAsync(string email);
    }
}
