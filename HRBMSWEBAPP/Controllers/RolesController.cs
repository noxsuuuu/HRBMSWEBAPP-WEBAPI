using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace HRBMSWEBAPP.Controllers
{
    //[Authorize(Roles = "Administrator")]
    public class RolesController : Controller
    {
        public RoleManager<IdentityRole> _roleManager; //{ get; }
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel roleViewModel,IdentityRole rolemodel)
        {
            if (!_roleManager.RoleExistsAsync(rolemodel.Name).GetAwaiter().GetResult())
            {

                if (ModelState.IsValid)
                {
                    //var newUser = new ApplicationUser
                    //{
                    //    Id = Guid.NewGuid(),
                    //    UserName = "username",
                    //    // Other user properties
                    //};

                    var role = new IdentityRole
                    {
                        Name = roleViewModel.Name
                    };
                    var result = await _roleManager.CreateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("GetAllRoles");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                //popup message
            }
            //else
                //popup message
               // TempData["ErrorMessage"] = "User role already exist";
            return View(roleViewModel);
        }


        [HttpGet]
        public IActionResult GetAllRoles()
        {
            return View(_roleManager.Roles.ToList());
            //RoleViewModel role = this._roleManager.to();
            //return View(role);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string? id)
        {
            //var role = await _roleManager.FindByIdAsync(id);
            //var getroles = await _roleManager.GetRoleIdAsync(role);
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            var roleViewModel = new RoleViewModel
            {
                Name = role.Name
            };

            return View(roleViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleViewModel roleViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(roleViewModel);
            }

            var existingRole = await _roleManager.FindByIdAsync(roleViewModel.Id.ToString());

            if (existingRole == null)
            {
                return NotFound();
            }

            existingRole.Name = roleViewModel.Name;
            existingRole.NormalizedName = roleViewModel.Name.ToUpperInvariant(); // Update the normalized name

            var result = await _roleManager.UpdateAsync(existingRole);

            if (!result.Succeeded)
            {
                // Handle the error
            }

            return RedirectToAction("GetAllRoles");
        }



        //[HttpPost]
        //public async Task<IActionResult> Update(IdentityRole role, string? id)
        //{
        //    //await _repo.UpdateRoomCategories(category.Id, category);
        //    //return RedirectToAction("GetAllRoomCategories");
        //    var roles = await _roleManager.FindByIdAsync(id);

        //    if (roles == null)
        //    {
        //        return NotFound();
        //    }

        //    var roleViewModel = new RoleViewModel
        //    {
        //        Name = roles.Name
        //    };
        //    await _roleManager.UpdateAsync(roleViewModel);
        //    // role = await _roleManager.FindByIdAsync(id);

        //    //var existingRole = await _roleManager.FindByIdAsync(role.Id.ToString());

        //    //// Update the role properties
        //    //existingRole.Name = role.Name;
        //    //existingRole.NormalizedName = role.Name.ToUpperInvariant();

        //    //// Update the role in the database
        //    //var result = await _roleManager.UpdateAsync(existingRole);

        //    //if (!result.Succeeded)
        //    //{
        //    //    // Handle the error
        //    //}

        //    //// Redirect to the roles list page
        //    return RedirectToAction("GetAllRoles");
        //}


        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Find the role by ID
            IdentityRole role = await _roleManager.FindByIdAsync(id);

            // If role is not found, return NotFound result
            if (role == null)
            {
                return NotFound();
            }

            // Convert IdentityRole to RoleViewModel
            RoleViewModel roleViewModel = new RoleViewModel
            {
                Id = Guid.Parse(role.Id),
                Name = role.Name
            };

            return View(roleViewModel);
        }

        //public async Task<IActionResult> Delete(string roleId)
        //{

        //    var roomlist = _roleManager.DeleteAsync(roleId);
        //    return RedirectToAction(controllerName: "Roles", actionName: "GetAllRoles");


        //}

        public async Task<IActionResult> Delete(Guid Id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(Id.ToString());
            var result = await _roleManager.DeleteAsync(role);
            return RedirectToAction(controllerName: "Roles", actionName: "GetAllRoles");

            //if (Id == null)
            //{
            //    return NotFound();
            //}

            //// Find the role by ID

            //IdentityRole role = await _roleManager.FindByIdAsync(Id.ToString());


            //// If role is not found, return NotFound result
            //if (role == null)
            //{
            //    return NotFound();
            //}
        
            //// Delete the role

            //var result = await _roleManager.DeleteAsync(role);

            //if (result.Succeeded)
            //{
            //    return RedirectToAction("GetAllRoles", "Roles");
            //}
            //else
            //{
            //    // Handle errors if any
            //    foreach (var error in result.Errors)
            //    {
            //        ModelState.AddModelError(string.Empty, error.Description);
            //    }

            //    // Redirect to appropriate view with error messages
            //    return View("ErrorView");
            //}
        }
    }
}
