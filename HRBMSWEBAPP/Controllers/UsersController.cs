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
            // ApplicationUser appuser = await this._userManager.GetUserId(id);
            if (id == null)
            {
                return NotFound();
            }
                
            ApplicationUser user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }


            return View(user);
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
        public async Task<IActionResult> Update(string? userId, IdentityRole id)
        {

            var user = await _roleManager.GetRoleIdAsync(id);
            ApplicationUser appuser = await _userManager.FindByIdAsync(user);
            //string roleid = "a534d2c6-1f94-46c8-84a1-4379a1fc912a";
           // var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
           // var roles = await _roleManager.GetRoleIdAsync(role);
            EditUserViewModel userViewModel = new EditUserViewModel()
            {
                FirstName = appuser.FirstName,
                LastName = appuser.LastName,
                Email = appuser.Email,
                PhoneNumber = appuser.PhoneNumber,
                //Roles = appuser.
            };
            return View(userViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateAsync(EditUserViewModel edituser,string id)
        {
            IdentityUser identity = new IdentityUser();
            var user = _userManager.FindByIdAsync(identity.Id);
         //   var result = await _roleManager.UpdateAsync(existingRole);
            await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            return RedirectToAction("GetAllUsers");
        }
    }
}
