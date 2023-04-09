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
        private readonly IRoomCatDBRepository _repo1;


        public HomeController(IRoomDBRepository repo, IRoomCatDBRepository repo1, ILogger<HomeController> logger)
        {
            this._repo = repo;
            this._repo1 = repo1;
            this._logger = logger;
        }

        public async Task<IActionResult> Index()
        {

            List<RoomCategories> room = await this._repo1.GetAllRoomCategories();
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

       /* public async Task<IActionResult> DashboardActionsAsync()
        {
            List<Room> room = await this._repo.GetAllRoom();
            return View(room);

        }*/
    }
}