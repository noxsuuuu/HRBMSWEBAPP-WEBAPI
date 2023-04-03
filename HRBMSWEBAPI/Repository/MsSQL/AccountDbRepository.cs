using HRBMSWEBAPI.DTO;
using HRBMSWEBAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace HRBMSWEBAPI.Repository.MsSQL
{
    public class AccountDbRepository : IAccountRepository
    {
        public UserManager<User> _userManager { get; }
        public SignInManager<User> _signInManager { get; }

        public AccountDbRepository(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<User> SignUpUserAsync(User user, string password)
        {
            var newUser = await _userManager.CreateAsync(user);
            if (newUser.Succeeded)
            {
                return user;
            }
            return null;
        }

        public async Task<SignInResult> SignInUserAsync(LoginDTO loginDTO)
        {
            var loginResult = await _signInManager.PasswordSignInAsync(loginDTO.UserName, loginDTO.Password, loginDTO.RememberMe, false);
            return loginResult;
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

       
    }
}
