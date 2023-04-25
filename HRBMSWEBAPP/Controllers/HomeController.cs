﻿using HRBMSWEBAPP.Models;
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
             var user = _userService.GetUserFirstName();
             ViewBag.UserId = user;
             List<Room> room = await this._repo.GetAllRoom();
             return View(room);
        }


        public ActionResult StaticPage()
        {
            return View("StaticPage");
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

    }
}