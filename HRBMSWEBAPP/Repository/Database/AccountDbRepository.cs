
using HRBMSWEBAPP.ViewModel;
using HRBMSWEBAPP.Models;
using Microsoft.AspNetCore.Identity;

using NuGet.Protocol;
using HRBMSWEBAPP.Service;

namespace HRBMSWEBAPP.Repository.DbRepository
{
    public class AccountDbRepository : IAccountDBRepository
    {
        private UserManager<ApplicationUser> _userManager { get; }
        // login user details 
        private SignInManager<ApplicationUser> _signInManager { get; }
        private readonly IUserService _userService;

        public AccountDbRepository(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePassViewModel model)
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
           return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);


        }
    }
}
