using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRBMSWEBAPP.Controllers
{
    //[Authorize(Roles ="Admin, User")]
    public class RoomCategoryController : Controller
    {
        private readonly IRoomCatDBRepository _repo;

        public RoomCategoryController(IRoomCatDBRepository repo)
        {
            this._repo = repo;
        }


        public async Task<IActionResult> GetAllRoomCategories()
        {

            List<RoomCategories> catlist = await _repo.GetAllRoomCategories();
            return View(catlist);
 
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RoomCategories categories = await this._repo.GetRoomCategoriesById((int)id);
            return View(categories);
        }

        public IActionResult Delete(int id)
        {
            var catlist = _repo.DeleteRoomCategories(id);
            return RedirectToAction(controllerName: "RoomCategory", actionName: "GetAllRoomCategories");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoomCategories category)
        {
            if (ModelState.IsValid)
            {
                var cat = _repo.AddRoomCategories(category);
                return RedirectToAction("GetAllRoomCategories");
            }
            ViewData["Message"] = "Data is not valid to create the category";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var old = await this._repo.GetRoomCategoriesById(id);
            return View(old);

        }


        [HttpPost]
        public async Task<IActionResult> Update(RoomCategories category)
        {
            await _repo.UpdateRoomCategories(category.Id, category);
            return RedirectToAction("GetAllRoomCategories");
        }



    }
}
