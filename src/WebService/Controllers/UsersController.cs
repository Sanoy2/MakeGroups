using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            var signedUsers = this.usersService.Get();

            return View(signedUsers);
        }
    }
}
