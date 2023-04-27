
using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.Repository;
using HRBMSWEBAPP.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPP.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager { get; }
        // login user details 
        private SignInManager<ApplicationUser> _signInManager { get; }
        public RoleManager<IdentityRole> _roleManager { get; }
        public IAccountDBRepository _accountRepository { get; }

        public AccountController(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                RoleManager<IdentityRole> roleManager,
                                IAccountDBRepository AccountRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _accountRepository = AccountRepository;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var userModel = new ApplicationUser
                {
                    UserName = userViewModel.Email,
                    Email = userViewModel.Email,
                    FirstName = userViewModel.FirstName,
                    LastName = userViewModel.LastName,
                    PhoneNumber = userViewModel.PhoneNumber,

                };
                var result = await _userManager.CreateAsync(userModel, userViewModel.Password);
                if (result.Succeeded)
                {
                    ViewBag.RegisterSuccess = true;
                    var role = await _roleManager.FindByNameAsync("Guest");
                    // Add the user to the role
                    await _userManager.AddToRoleAsync(userModel, role.Name);
                    ViewBag.Success = true;
                    // login the user automatically
                    return RedirectToAction("Login");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(userViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel userViewModel)
        {
       

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userViewModel.UserName, userViewModel.Password, userViewModel.RememberMe, false);

                if (result.Succeeded)
                {
                    ViewBag.LoginSuccess = true;
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Login Failed!");
            }

            return View(userViewModel);


        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.ChangePasswordAsync(model);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    return View();
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
    }
}
