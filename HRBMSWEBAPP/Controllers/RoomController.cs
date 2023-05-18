using HRBMSWEBAPP.Data;
using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.Repository;
using HRBMSWEBAPP.Repository.Rest;
using HRBMSWEBAPP.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using TodoMinimalWebApp.Models;

namespace HRBMSWEBAPP.Controllers
{
    //[Authorize(Roles = "Admin, Staff")]
    public class RoomController : Controller
    {
        private readonly IRoomDBRepository _repo;
        private readonly IRoomsRepository _roomsRest;
        HRBMSDBCONTEXT _context;
        private readonly IConfiguration _configs;
        private readonly HttpClient _httpClient;

        public RoomController(IRoomDBRepository repo, HRBMSDBCONTEXT context, IRoomsRepository roomsRest, IConfiguration configs)

        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:7098/api");
            this._repo = repo;
            _context = context;
            _configs = configs;
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

            // use access token to call a protected web API
            var token = HttpContext.Session.GetString("JWToken");
            List<Room> room = await this._roomsRest.GetAllRooms(token);
            return View(room);

            //List<Room> getallroom = await _repo.GetAllRoom();
            //return View(getallroom);
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


        public async Task<IActionResult> Delete(int id)
        {
            // Check if the room exists
            //restapi
            //var room = await _roomsRest.GetRoomById(roomId);
            var token = HttpContext.Session.GetString("JWToken");
            var room = await _repo.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }
            // Delete the room
            await _roomsRest.DeleteRoom(id, token);
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
                var token = HttpContext.Session.GetString("JWToken");
                _roomsRest.CreateRoom(newRoom, token);
                //_repo.AddRoom(newRoom);
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
            var token = HttpContext.Session.GetString("JWToken");
            await _roomsRest.UpdateRoom(newRoom.Id, newRoom, token);
            return RedirectToAction("GetAllRooms");
        }




    }
}
