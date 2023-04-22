
using HRBMSWEBAPP.Data;
using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPP.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
       
        private UserManager<ApplicationUser> _userManager;
        public RoleManager<IdentityRole> _roleManager;
        HRBMSDBCONTEXT _context;
        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, HRBMSDBCONTEXT context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
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


        public async Task<IActionResult> Delete(Guid Id)
        {
           

            ApplicationUser user = await _userManager.FindByIdAsync(Id.ToString());
            var result = await _userManager.DeleteAsync(user);
           // ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());
            return RedirectToAction(controllerName: "Users", actionName: "GetAllUsers"); // reload the getall page it self
        }

        [HttpGet]
        public IActionResult Create()
        {
            //var roleNames = _roleManager.Roles.Select(r => r.Name).ToList();
            //ViewBag.Role = roleNames;
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
        public async Task<IActionResult> Update(ApplicationUser Userr,string id)
        {

            var roleManager = HttpContext.RequestServices.GetService(typeof(RoleManager<IdentityRole>)) as RoleManager<IdentityRole>;
            var roles = await roleManager.Roles.ToListAsync();
            ViewBag.listofrole = roles;

            var user = await _userManager.FindByIdAsync(id);

            var usermodel = new ApplicationUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
              
            };
            

            return View(usermodel);
        }



        [HttpPost]
        public async Task<IActionResult> Update(string id, ApplicationUser user)
        {


            if (id != user.Id)
            {
                return BadRequest();
            }

            ApplicationUser existingUser = await _userManager.FindByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            // Update the user properties
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Role = user.Role;

            // Update the user role
            var userRole = await _userManager.GetRolesAsync(existingUser);
            IdentityRole role = await _roleManager.FindByNameAsync(userRole[0]);
            if (role == null)
            {
                return BadRequest();
            }
            await _userManager.RemoveFromRolesAsync(existingUser, userRole);
            await _userManager.AddToRoleAsync(existingUser, role.Name);

            // Update the user in the database
            var result = await _userManager.UpdateAsync(existingUser);
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            return RedirectToAction("GetAllUsers");
        }



    }
}
