using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRBMSWEBAPP.Controllers
{
    //[Authorize(Roles ="Admin, Guest")]
    public class RoomCategoryController : Controller
    {
        IRoomCatDBRepository _repo;

        public RoomCategoryController(IRoomCatDBRepository repo)
        {
            this._repo = repo;
        }


        public IActionResult GetAllRoomCategories()
        {
            var catlist = _repo.GetAllRoomCategories();
            return View(catlist);

        }

        public IActionResult Details(int catId)
        {
            var cat = _repo.GetRoomCategoriesById(catId);
            return View(cat);
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

        [HttpPost]
        public IActionResult Update(RoomCategories category)
        {
            var cat = _repo.UpdateRoomCategories(category.Id, category);
            return RedirectToAction("GetAllRoomCategories");
        }



    }
}
