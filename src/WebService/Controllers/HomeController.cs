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
        private readonly ITeamsService teamsService;

        public HomeController(ILogger<HomeController> logger, IUsersService usersService, ITeamsService teamsService)
        {                                                     
            this.logger = logger;
            this.usersService = usersService;
            this.teamsService = teamsService;
        }

        public IActionResult Index()
        {
            var current = WindowsIdentity.GetCurrent();

            var message = $"Name: {current.Name.ToString()}";

            this.logger.LogInformation(message);

            UserViewModel user = new UserViewModel(current.Name);

            return View(user);
        }

        public IActionResult Teams()
        {
            var teamViewModels = this.teamsService.SplitUsersToGroup(4);

            return View(teamViewModels);
        }

        [HttpPost]
        public IActionResult Register()
        {
            var user = WindowsIdentity.GetCurrent();

            string userNameWithDomain = user.Name;

            this.usersService.Add(userNameWithDomain);

            return RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        public IActionResult Unregister()
        {
            var user = WindowsIdentity.GetCurrent();

            string userNameWithDomain = user.Name;

            this.usersService.Remove(userNameWithDomain);

            return RedirectToAction(nameof(this.Index));
        }

        [HttpDelete]
        public IActionResult Unregister2()
        {
            var user = WindowsIdentity.GetCurrent();

            string userNameWithDomain = user.Name;

            this.usersService.Remove(userNameWithDomain);

            return RedirectToAction(nameof(this.Index));
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
