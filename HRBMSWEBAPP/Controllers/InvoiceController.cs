using HRBMSWEBAPP.Data;
using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRBMSWEBAPP.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IinvoiceDBRepository _repo;
        private UserManager<ApplicationUser> _userManager;
        private readonly IBookingDBRepository _bookrepo;
        IRoomDBRepository _Roomrepo;
        HRBMSDBCONTEXT _context;
        public InvoiceController(IinvoiceDBRepository repo, 
                                UserManager<ApplicationUser> userManager,
                                IBookingDBRepository bookrepo,
                                IRoomDBRepository Roomrepo,
                                HRBMSDBCONTEXT context)
        {
            _repo = repo;
            _userManager = userManager;
            _bookrepo = bookrepo;
            _context = context;
            _Roomrepo = Roomrepo;
        }

        public async Task<IActionResult> GetAllInvoice()
        {
            List<Invoice> invoice = await this._repo.GetAllInvoice();
            return View(invoice);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Invoice invoice = await this._repo.GetInvoiceById((int)id);
            return View(invoice);
        }

        public IActionResult Delete(int id)
        {
            var invoicelist = _repo.DeleteInvoice(id);
            return RedirectToAction(controllerName: "Invoice", actionName: "GetAllInvoice");
        }

        [HttpGet]
        public IActionResult Create()
        {
            Booking book = new Booking();
            Invoice invoice = new Invoice();
            // Query the database and retrieve all Booking records into a list
            var bookingList = _context.Booking.ToList();

            // Get the first Booking record from the list
            var booking = bookingList.FirstOrDefault();

            //if (booking != null)
            //{
            //    // Assign the CheckIn and CheckOut values to the new Booking object
            //    book.CheckIn = booking.CheckIn;
            //    book.CheckOut = booking.CheckOut;
            //}

            // Access the CheckIn and CheckOut properties
            DateTime checkIn = booking.CheckIn;
            DateTime checkOut = booking.CheckOut;

            // Define the hourly rate
            decimal hourlyRate = 100;



            // Calculate the time span between the two dates
            TimeSpan timeSpan = checkOut - checkIn;

            // Calculate the total number of hours
            double totalHours = timeSpan.TotalHours;

            // Calculate the total book price
            decimal totalBookPrice = hourlyRate * (decimal)totalHours;

            // Assign the total book price to a property on the view model
            invoice.TotalPrice = (double)totalBookPrice;
            var model = new Invoice
            {
                TotalPrice = (double)totalBookPrice
            };

            List<ApplicationUser> userlist = new List<ApplicationUser>();
            userlist = _userManager.Users.ToList();
            ViewBag.listofUser = userlist;

            List<Room> roomlist = new List<Room>();
            roomlist = _context.Room.ToList();
            ViewBag.listofroom = roomlist;

            List<RoomCategories> catlist = new List<RoomCategories>();
            catlist = _context.Categories.ToList();
            ViewBag.listofcat = catlist;

            List<Booking> booklist = new List<Booking>();
            booklist = _context.Booking.ToList();
            ViewBag.listofbook = booklist;

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Invoice invoice)
        {
           
            if (ModelState.IsValid)
            {
               
                var _invoice = _repo.AddInvoice(invoice);
                if (invoice == null)
                {

                }
                return RedirectToAction("GetAllInvoice");
            }
            ViewData["Message"] = "Data is not valid to create the Invoice";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            List<ApplicationUser> userlist = new List<ApplicationUser>();
            userlist = _userManager.Users.ToList();
            ViewBag.listofUser = userlist;

            List<Room> roomlist = new List<Room>();
            roomlist = _context.Room.ToList();
            ViewBag.listofroom = roomlist;

            List<RoomCategories> catlist = new List<RoomCategories>();
            catlist = _context.Categories.ToList();
            ViewBag.listofcat = catlist;

            List<Booking> booklist = new List<Booking>();
            booklist = _context.Booking.ToList();
            ViewBag.listofbook = booklist;

            var old = await this._repo.GetInvoiceById(id);
            return View(old);

        }

        [HttpPost]
        public async Task<IActionResult> Update(Invoice invoice)
        {

            await _repo.UpdateInvoice(invoice.Id, invoice);
            return RedirectToAction("GetAllInvoice");
        }
    }
}
