using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using WebService.Models;
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
            IEnumerable<TeamViewModel> teams = this.teamsService.SplitUsersToGroup(groupsCount).ToList();

            var user = WindowsIdentity.GetCurrent();

            string userNameWithDomain = user.Name;

            string userName = userNameWithDomain.Split('\\').Last();

            var teamWithUser = teams.FirstOrDefault(x => x.Users.Any(u => u.Name == userName));
            if(teamWithUser != null)
            {
                var userViewModel = teamWithUser.Users.First(x => x.Name == userName);
                userViewModel.Highlight();
            }    

            return View(teams);
        }
    }
}
