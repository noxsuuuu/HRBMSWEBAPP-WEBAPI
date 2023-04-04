using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRBMSWEBAPP.Controllers
{
    //[Authorize(Roles ="Admin, Guest")]
    public class BookingController : Controller
    {

       private readonly IBookingDBRepository _repo;

       
        public BookingController(IBookingDBRepository repo)
        {
            this._repo = repo;
        }

        //public IActionResult GetAllBookings()
        //{
        //    var booklist = _repo.GetAllBooking();
        //    return View(booklist);

        //}
        public async Task<IActionResult> GetAllBookings()
        {
            List<Booking> booking = await this._repo.GetAllBooking();
            return View(booking);
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


        //public IActionResult Details(int bookId)
        //{
        //    var book = _repo.GetBookingById(bookId);
        //    return View(book);
        //}

        public IActionResult Delete(int id)
        {
            var booklist = _repo.DeleteBooking(id);
            return RedirectToAction(controllerName: "Booking", actionName: "GetAllBookings");
        }

        [HttpGet]
        public IActionResult Create()
        {
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

        [HttpPost]
        public IActionResult Update(Booking booking)
        {
            var book = _repo.UpdateBooking(booking.Id, booking);
            return RedirectToAction("GetAllBookings");
        }
    }
}
