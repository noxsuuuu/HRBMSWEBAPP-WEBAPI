using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HRBMSWEBAPP.Controllers
{
    //[Authorize(Roles = "Administrator")]
    public class RolesController : Controller
    {
        public RoleManager<IdentityRole> _roleManager { get; }
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
        public async Task<IActionResult> Create(RoleViewModel roleViewModel)
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
        public async Task<IActionResult> Update(string roleId)
        {
            var oldTodo = await _roleManager.FindByIdAsync(roleId);
            return View(oldTodo);
        }
        [HttpPost]
        public async Task<IActionResult> Update(RoleViewModel role)
        {
            var oldRole = await _roleManager.FindByIdAsync(role.Id.ToString());
            oldRole.Name = role.Name;
            var result = await _roleManager.UpdateAsync(oldRole);
            if (result.Succeeded)
            {
                return RedirectToAction("GetAllRoles");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View();
        }

        //public IActionResult Details(string roleId)
        //{
        //    var role = _roleManager.FindByIdAsync(roleId);
        //    return View(role.Result);
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
