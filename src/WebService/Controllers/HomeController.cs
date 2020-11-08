using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using Domain.Implementations;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using WebService.Models;
using WebService.Services;

namespace WebService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IUsersService usersService;

        public HomeController(ILogger<HomeController> logger, IUsersService usersService)
        {                                                     
            this.logger = logger;
            this.usersService = usersService;
        }

        public IActionResult Index()
        {
            var current = WindowsIdentity.GetCurrent();

            var message = $"Name: {current.Name.ToString()}";

            this.logger.LogInformation(message);

            UserViewModel user = new UserViewModel(current.Name);

            return View(user);
        }

        [HttpPost]
        public IActionResult Register()
        {
            var user = WindowsIdentity.GetCurrent();

            string userNameWithDomain = user.Name;

            this.usersService.Add(userNameWithDomain);

            return RedirectToAction("Index", "Users");
        }

        [HttpPost]
        public IActionResult Unregister()
        {
            var user = WindowsIdentity.GetCurrent();

            string userNameWithDomain = user.Name;

            this.usersService.Remove(userNameWithDomain);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
