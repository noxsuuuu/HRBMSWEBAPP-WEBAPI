
//using HRBMSWEBAPP.Models;
//using HRBMSWEBAPP.Repository;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace HRBMSWEBAPP.Controllers
//{
//    //[Authorize(Roles = "Admin, Staff")]
//    public class RoomController : ControllerBase
//    {
//        private readonly IRoomDBRepository _repo;
//        private readonly IMapper _mapper;

//        public RoomController(IRoomDBRepository repo, IMapper _mapper)
//        {
//            this._repo = repo;
//            this._mapper = _mapper;
//        }

//        public async Task<IActionResult> GetAll()
//        {
//            //List<Room> room = await this._repo.GetAllRoom();
           
//            return Ok(_repo.GetAllRoom());
            
//        }

   
//        //public async Task<IActionResult> Details(int? id)
//        //{
//        //    if (id == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    Room room = await this._repo.GetRoomById((int)id);
//        //    return View(room);
//        //}

//        ////public IActionResult Delete(int id)
//        ////{
//        ////    var roomlist = _repo.DeleteRoom(id);
//        ////    return RedirectToAction(controllerName: "Room", actionName: "GetAllRooms");
//        ////}

//        //public IActionResult Delete(int id)
//        //{
//        //    var roomlist = _repo.DeleteRoom(id);
//        //    return RedirectToAction(controllerName: "Room", actionName: "GetAllRooms");
//        //}

//        //[HttpGet]
//        //public IActionResult Create()
//        //{
//        //    return View();
//        //}


//        ////public IActionResult Create(Room newRoom)
//        ////{
//        ////    if (ModelState.IsValid)
//        ////    {
//        ////        var room = _repo.AddRoom(newRoom);
//        ////        return RedirectToAction("GetAllRooms");
//        ////    }
//        ////    ViewData["Message"] = "Data is not valid to create the Room";
//        ////    return View();
//        ////}

//        //[HttpGet]
//        //public async Task<IActionResult> Update(int id)
//        //{
//        //    var old = await this._repo.GetRoomById(id);
//        //    return View(old);

//        //}

//        //[HttpPost]
//        //public async Task<IActionResult> Update(Room newRoom)
//        //{
//        //    await _repo.UpdateRoom(newRoom.Id, newRoom);
//        //    return RedirectToAction("GetAllRooms");
//        //}

//        //[HttpPost]
//        //public IActionResult Create(Room newRoom)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        var book = _repo.AddRoom(newRoom);
//        //        return RedirectToAction("GetAllRooms");
//        //    }
//        //    ViewData["Message"] = "Data is not valid to create the Room";
//        //    return View();
//        //}



//    }
//}
