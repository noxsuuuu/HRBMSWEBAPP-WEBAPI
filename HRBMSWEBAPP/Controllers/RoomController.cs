using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRBMSWEBAPP.Controllers
{
    [Authorize(Roles = "Administrator, Staff")]
    public class RoomController : Controller
    {
        IRoomDBRepository _repo;

        public RoomController(IRoomDBRepository repo)
        {
            _repo = repo;
        }

        public IActionResult GetAllRooms()
        {
            var roomlist = _repo.GetAllRoom();
            return View(roomlist);
        }

        public IActionResult Details(int roomId)
        {
            var room = _repo.GetRoomById(roomId);
            return View(room);
        }

        public IActionResult Delete(int id)
        {
            var roomlist = _repo.DeleteRoom(id);
            return RedirectToAction(controllerName: "Room", actionName: "GetAllRooms");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Room newRoom)
        {
            if (ModelState.IsValid)
            {
                var room = _repo.AddRoom(newRoom);
                return RedirectToAction("GetAllRooms");
            }
            ViewData["Message"] = "Data is not valid to create the Room";
            return View();
        }

        [HttpPost]
        public IActionResult Update(Room newRoom)
        {
            var room = _repo.UpdateRoom(newRoom.Id, newRoom);
            return RedirectToAction("GetAllRooms");
        }


    }
}
