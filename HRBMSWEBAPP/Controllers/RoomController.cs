using HRBMSWEBAPP.Data;
using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.Repository;
using HRBMSWEBAPP.Repository.Rest;
using HRBMSWEBAPP.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRBMSWEBAPP.Controllers
{
    //[Authorize(Roles = "Admin, Staff")]
    public class RoomController : Controller
    {
        private readonly IRoomDBRepository _repo;
        private readonly IRoomsRepository _roomsRest;
        HRBMSDBCONTEXT _context;

        public RoomController(IRoomDBRepository repo , HRBMSDBCONTEXT context, IRoomsRepository roomsRest)
        {
            this._repo = repo;
            _context = context;
            _roomsRest = roomsRest;
        }

     
        public async Task<IActionResult> GetAllRooms(string searchString)
        {
            var roomlist = from books in _repo.GetAllRoom1()
                           select books;
            if (!String.IsNullOrEmpty(searchString))
            {
                roomlist = roomlist.Where(s => s.Category.Room_Name.ToLower().Contains(searchString.Trim().ToLower()));
                return View(roomlist.ToList());
            }
            //sql
            //List<Room> room = await this._repo.GetAllRoom();
            //return View(room);

            //stored procedure
            var roomlistsp = _roomsRest.spGetAllRooms();
            return View(roomlistsp);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room room = await this._repo.GetRoomById((int)id);
            return View(room);
        }
   

        public async Task<IActionResult> Delete(int roomId)
        {
            // Check if the room exists
            //restapi
            //var room = await _roomsRest.GetRoomById(roomId);
            var room = await _repo.GetRoomById(roomId);
            if (room == null)
            {
                return NotFound();
            } 
            // Delete the room
            await _roomsRest.DeleteRoom(roomId);
            return RedirectToAction("GetAllRooms");
        }
       
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Room newRoom)
        {
            if (ModelState.IsValid)
            {
                //consuming rest api
                //_roomsRest.CreateRoom(newRoom);

                _repo.AddRoom(newRoom);         
                return RedirectToAction("GetAllRooms");
            }

            // If ModelState is invalid, collect the validation errors
            var errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
            ViewData["Message"] = "Data is not valid to create the Room";
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }



       

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            
            ViewBag.Categories = _context.Categories.ToList();
            var old = await this._repo.GetRoomById(id);
            return View(old);

        }

        [HttpPost]
        public async Task<IActionResult> Update(Room newRoom)
        {
            await _repo.UpdateRoom(newRoom.Id, newRoom);
            return RedirectToAction("GetAllRooms");
        }




    }
}
