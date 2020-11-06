using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using Domain.Implementations;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebService.Models;

namespace WebService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
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
            ITeamCreator teamCreator = new TeamCreator();
            IUsersCollection users = new FakeUsersCollection();

            var teams = teamCreator.Create(users.Get(), 2);

            IEnumerable<TeamViewModel> teamViewModels = teams.Select(x => this.ToTeamViewModel(x));

            return View(teamViewModels);
        }

        [HttpPost]
        public IActionResult Register()
        {
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

        private TeamViewModel ToTeamViewModel(Team team)
        {
            var teamViewModel = new TeamViewModel()
            {
                Name = team.Name
            };

            foreach (var user in team.Users)
            {
                UserViewModel userViewModel = new UserViewModel()
                {
                    Name = user.Name
                };

                teamViewModel.Users.Add(userViewModel);
            }

            return teamViewModel;
        }
    }
}
