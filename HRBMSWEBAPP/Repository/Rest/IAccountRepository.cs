using Microsoft.AspNetCore.Identity;
using HRBMSWEBAPP.ViewModel;
using HRBMSWEBAPP.Models;

namespace HRBMSWEBAPP.Repository.Rest
{
    public interface IAccountRepository
    {
        Task<bool> SignUpUserAsync(RegisterViewModel user);
        Task<string> SignInUserAsync(LoginUserViewModel loginUserViewModel);
    }
}
