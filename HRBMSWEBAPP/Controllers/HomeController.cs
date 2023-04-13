using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.Repository;
using HRBMSWEBAPP.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HRBMSWEBAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRoomDBRepository _repo;
       


        public HomeController(IRoomDBRepository repo, ILogger<HomeController> logger)
        {
            this._repo = repo;
           
            this._logger = logger;
        }

        public async Task<IActionResult> Index()
        {

            List<Room> room = await this._repo.GetAllRoom();
            return View(room);
        }
       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /*public async Task<IActionResult> Profile()
        {

            List<ApplicationUser> user = await this.
            return View();
        }*/

        /* public async Task<IActionResult> DashboardActionsAsync()
         {
             List<Room> room = await this._repo.GetAllRoom();
             return View(room);

         }*/
    }
}