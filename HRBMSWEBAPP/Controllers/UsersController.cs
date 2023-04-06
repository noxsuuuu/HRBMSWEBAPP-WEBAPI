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
        public RoleManager<IdentityRole> _roleManager; //{ get; }
        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        // [AllowAnonymous]


        public async Task<IActionResult> GetAllUsers()
        {
            var userlist = await _userManager.Users.ToListAsync();
            return View(userlist);
        }

        public async Task<IActionResult> Details(string? id)
        {
            ApplicationUser user = await this._userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            // Get the roles associated with the user
            var userRole = await _userManager.GetRolesAsync(user);
            IdentityRole role = await _roleManager.FindByNameAsync(userRole[0]);

            ApplicationUser model = new ApplicationUser
            {   
                Email = user.Email, 
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Role = role
            };
            
            return View(model);

        }


        public async Task<IActionResult> Delete(string Id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(Id);
            var result = await _userManager.DeleteAsync(user);
           // ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());
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
                    var role = await _roleManager.FindByNameAsync("Guest");

                    // Add the user to the role
                    await _userManager.AddToRoleAsync(userModel, role.Name);
                    return RedirectToAction("GetAllUsers");

                    // notify user created POP_UP MESSAGE PLEASEE

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(userViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Update(string userId, ApplicationUser Userr)
        {

            var appuser = await _userManager.GetUserIdAsync(Userr);
            var user = await _userManager.FindByIdAsync(appuser);
            var userRole = await _userManager.GetRolesAsync(user);
            IdentityRole role = await _roleManager.FindByNameAsync(userRole[0]);
            ApplicationUser  usermodel = new ApplicationUser
            {
               FirstName = user.FirstName,
               LastName = user.LastName,
               Email = user.Email,
               PhoneNumber= user.PhoneNumber,
               Role = role
            };

            return View(usermodel);
        }


        [HttpPost]
        public async Task<IActionResult> Update(EditUserViewModel edituser,string id)
        {
            if (!ModelState.IsValid)
            {
                return View(edituser);
            }

            var existinguser = await _roleManager.FindByIdAsync(edituser.Id.ToString());

            if (existinguser == null)
            {
                return NotFound();
            }


            //var result = await _userManager.UpdateAsync(existinguser);

            //if (!result.Succeeded)
            //{
            //    // Handle the error
            //}

            return RedirectToAction("GetAllUsers");
        }
    }
}
