using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPP.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        // [AllowAnonymous]


        public async Task<IActionResult> GetAllUsers()
        {
            var userlist = await _userManager.Users.ToListAsync();
            return View(userlist);
        }

        public async Task<IActionResult> Details(string? id, IdentityUser iuser)
        {
         // ApplicationUser appuser = await this._userManager.GetUserId(id);
        
        //   var result = await _userManager.CreateAsync(userModel, userViewModel.Password);
        var user = await _userManager.FindByIdAsync(iuser.Id);

            //if (user == null)
            //{
            //    return NotFound();
            //}

            var viewModel = new RegisterViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return View(viewModel);
        }
        //public async Task<IActionResult> Details(string? userId)
        //{
        //    if (userId == null)
        //    {
        //        return NotFound();
        //    }

        //    ApplicationUser user = await _userManager.FindByIdAsync(userId);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    // Convert user to registerViewModel 
        //    RegisterViewModel registerViewModel = new RegisterViewModel
        //    {

        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        Email = user.Email,
        //        PhoneNumber = user.PhoneNumber
        //    };

        //    return View(registerViewModel);
        //}


        public async Task<IActionResult> Delete(string userId)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            var userlist = await _userManager.DeleteAsync(user);
            return RedirectToAction(controllerName: "Users", actionName: "GetAllUsers"); // reload the getall page it self
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterViewModel userViewModel) // model binded this where the views data is accepted 
        {
            if (ModelState.IsValid)
            {
                var userModel = new ApplicationUser
                {
                    UserName = userViewModel.Email,
                    Email = userViewModel.Email,
                    FirstName = userViewModel.FirstName,
                    LastName = userViewModel.LastName,
                    PhoneNumber = userViewModel.PhoneNumber
                    
                    
                };
                var result = await _userManager.CreateAsync(userModel, userViewModel.Password);
                if (result.Succeeded)
                {
                    // notify user created

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(userViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var roles = await _userManager.GetRolesAsync(user);
            EditUserViewModel userViewModel = new EditUserViewModel()
            {
                FirstName = user.FirstName,
                Email = user.Email,
                LastName = user.LastName,
                Roles = roles
            };
            return View(userViewModel);
        }
        [HttpPost]
        public IActionResult Update(EditUserViewModel user)
        {
            //var user = _userManager.Users.FirstOrDefault(u => u.Id == newUser);

            return RedirectToAction("GetAllUsers");
        }
    }
}
