using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebService.Services;

namespace WebService.Controllers
{
    [Route("[controller]/[action]")]
    public class TeamsController : Controller
    {
        private readonly ITeamsService teamsService;

        public TeamsController(ITeamsService teamsService)
        {
            this.teamsService = teamsService;
        }

        public IActionResult Split(int groupsCount)
        {
            var teams = this.teamsService.SplitUsersToGroup(groupsCount);

            return View(teams);
        }
    }
}
