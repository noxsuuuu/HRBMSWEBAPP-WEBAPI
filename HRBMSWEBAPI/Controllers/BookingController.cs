using Microsoft.AspNetCore.Mvc;

namespace HRBMSWEBAPI.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
