using HRBMSWEBAPP.Data;
using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.Repository;
using HRBMSWEBAPP.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRBMSWEBAPP.Controllers
{
    //[Authorize(Roles = "Admin, Staff")]
    public class RoomController : Controller
    {
        private readonly IRoomDBRepository _repo;
        HRBMSDBCONTEXT _context;

        public RoomController(IRoomDBRepository repo , HRBMSDBCONTEXT context)
        {
            this._repo = repo;
            _context = context;
        }

        //public IActionResult GetAllRooms()
        //{
        //    var roomlist = _repo.GetAllRoom();
        //    return View(roomlist);
        //}
        public async Task<IActionResult> GetAllRooms()
        {
            List<Room> room = await this._repo.GetAllRoom();
            return View(room);
           // return this._context.Room.Include(e => e.Category.Room_Name).AsNoTracking().ToListAsync();
        }

        //public IActionResult Details(int roomId)
        //{
        //    var room = _repo.GetRoomById(roomId);
        //    return View(room);
        //}
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    Booking booking = await this._repo.GetBookingById((int)id);
        //    return View(booking);
        //}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room room = await this._repo.GetRoomById((int)id);
            return View(room);
        }

        //public IActionResult Delete(int id)
        //{
        //    var roomlist = _repo.DeleteRoom(id);
        //    return RedirectToAction(controllerName: "Room", actionName: "GetAllRooms");
        //}

        public IActionResult Delete(int id)
        {
            var roomlist = _repo.DeleteRoom(id);
            return RedirectToAction(controllerName: "Room", actionName: "GetAllRooms");
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
                _repo.AddRoom(newRoom);
                return RedirectToAction("GetAllRooms");
            }

            // If ModelState is invalid, collect the validation errors
            var errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
            ViewData["Message"] = "Data is not valid to create the Room";
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }



        /* [HttpGet]
         public IActionResult Create()
         {
             var categories = _context.Categories.ToList();
             if (categories == null)
             {
                 return NotFound();
             }
             ViewBag.listofcat = categories;
             return View();
         }

         [HttpPost]
         public IActionResult Create(Room newRoom)
         {

             if (ModelState.IsValid)
             {
                 var book = _repo.AddRoom(newRoom);
                 return RedirectToAction("GetAllRooms");
             }
             ViewData["Message"] = "Data is not valid to create the Room";
             return View();
         }*/
        //public IActionResult Create(Room newRoom)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var room = _repo.AddRoom(newRoom);
        //        return RedirectToAction("GetAllRooms");
        //    }
        //    ViewData["Message"] = "Data is not valid to create the Room";
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            //List<RoomCategories> li = new List<RoomCategories>();
            //li = _context.Categories.ToList();
            //ViewBag.listofcat = li;
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
