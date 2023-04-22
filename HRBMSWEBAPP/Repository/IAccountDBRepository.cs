using HRBMSWEBAPP.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace HRBMSWEBAPP.Repository
{
    public interface IAccountDBRepository
    {
        Task<IdentityResult> ChangePasswordAsync(ChangePassViewModel model);
    }
}
