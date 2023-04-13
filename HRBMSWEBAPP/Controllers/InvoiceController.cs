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

            return View();
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
