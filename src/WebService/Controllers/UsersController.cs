using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using WebService.Models;
using WebService.Services;

namespace WebService.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IUsersService usersService;
        private readonly ITeamsService teamsService;

        public UsersController(ILogger<HomeController> logger, IUsersService usersService, ITeamsService teamsService)
        {
            this.logger = logger;
            this.usersService = usersService;
            this.teamsService = teamsService;
        }

        public IActionResult Index()
        {
            IEnumerable<UserViewModel> signedUsers = this.usersService.Get().ToList();

            var user = WindowsIdentity.GetCurrent();

            string userNameWithDomain = user.Name;

            string userName = userNameWithDomain.Split('\\').Last();

            var currentUserViewModel = signedUsers.FirstOrDefault(x => x.Name == userName);
            if(currentUserViewModel != null)
            {
                currentUserViewModel.Highlight();
            }

            return View(signedUsers);
        }
    }
}
