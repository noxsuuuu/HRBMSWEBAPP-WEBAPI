using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.Repository;
using HRBMSWEBAPP.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HRBMSWEBAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRoomDBRepository _repo;
        public IUserService _userService { get; }

        public HomeController(IRoomDBRepository repo, ILogger<HomeController> logger, IUserService userService)
        {
            this._repo = repo;
           
            this._logger = logger;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var user = _userService.GetUserId();
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

       /* public async Task<IActionResult> DashboardActionsAsync()
        {
            List<Room> room = await this._repo.GetAllRoom();
            return View(room);

        }*/
    }
}