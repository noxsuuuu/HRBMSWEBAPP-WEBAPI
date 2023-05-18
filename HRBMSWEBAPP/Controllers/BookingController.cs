
using HRBMSWEBAPP.Data;
using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.Repository;
using HRBMSWEBAPP.Service;
using HRBMSWEBAPP.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HRBMSWEBAPP.Controllers
{
    //[Authorize(Roles ="Admin, User")]
    public class BookingController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IBookingDBRepository _repo;
       
        IRoomDBRepository _Roomrepo;
        private readonly IUserService _UserService;
        HRBMSDBCONTEXT _context;

        public BookingController(IBookingDBRepository repo, IRoomDBRepository Roomrepo, 
                                 HRBMSDBCONTEXT context, UserManager<ApplicationUser> userManager,
                                 IUserService userService)
        {
            this._repo = repo;
            _Roomrepo = Roomrepo;
            _context = context;
            _userManager = userManager;
            _UserService = userService;
        }


        public async Task<IActionResult> GetAllBookings(string searchString)
        {
          

            var booklist = from books in _repo.GetAllBooking1()
                           select books;
            if (!String.IsNullOrEmpty(searchString))
            {
                booklist = booklist.Where(s => s.User.Full_Name.ToLower().Contains(searchString.Trim().ToLower()));
                return View(booklist.ToList());
            }
            // use access token to call a protected web API
            var token = HttpContext.Session.GetString("JWToken");
            List<Booking> book = await this._repo.GetAllBooking(token);
            return View(book);
            //List <Booking> booking = await this._repo.GetAllBooking();
            //return View(booking);
        }

       
        public async Task<IActionResult> Details(int? id)
        {


            if (id == null)
            {
                return NotFound();
            }

         
            Booking booking = await this._repo.GetBookingById((int)id);
            return View(booking);
        }


   
        public async Task<IActionResult> Delete(int id)
        {
        
            // Check if the booking exists
            var booking = await this._repo.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            var token = HttpContext.Session.GetString("JWToken");
            var room = await this._Roomrepo.GetRoomById(booking.RoomId);
            if (room != null)
            {
                room.Status = true;
                _context.Room.Update(room);
                _context.SaveChanges();
            }
            // Delete the booking from the database
            await this._repo.DeleteBooking(id, token);

            // Redirect to the list of bookings
            return RedirectToAction("GetAllBookings");
        }

        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpGet]
        public IActionResult CreateRoomBooking(int roomId)
        {
            ViewData["RoomId"] = roomId;
            return View();
        }


        [HttpPost]
        public IActionResult CreateRoomBooking(int roomId, Booking booking)
        {
           

            if (ModelState.IsValid)
            {
                var userId = _UserService.GetUserId();
                booking.UserId = userId;
                booking.RoomId = roomId;
                // Save the booking to the database 
                 _context.Booking.Add(booking);
                _context.SaveChanges();
         
               

                var room = _context.Room.FirstOrDefault(r => r.Id == roomId);
                if (room != null)
                {
                    room.Status = false;
                    _context.Room.Update(room);
                    _context.SaveChanges();
                   
                       
                    
                }


             
                // Redirect to a thank-you page or back to the room list page
                return RedirectToAction("Success");
            }

            ViewData["Message"] = "Data is not valid to create the booking";
            ViewData["RoomId"] = roomId;
            return View();
        }


        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                var book = _repo.AddBooking(booking);
           
                return RedirectToAction("GetAllBookings");
            }
            ViewData["Message"] = "Data is not valid to create the booking";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            List<Room> li = new List<Room>();
            li = _context.Room.ToList();
            ViewBag.listofroom = li;

            List<ApplicationUser> userlist = new List<ApplicationUser>();
            userlist = _userManager.Users.ToList();
            ViewBag.listofUser = userlist;

            var old = await this._repo.GetBookingById(id);
            return View(old);

        }


        [HttpPost]
        public async Task<IActionResult> Update(Booking booking)
        {
            
            await _repo.UpdateBooking(booking.Id,booking);
            return RedirectToAction("GetAllBookings");
        }
        public IActionResult Success()
        {
            return View();
        }
      
        
    }
}
