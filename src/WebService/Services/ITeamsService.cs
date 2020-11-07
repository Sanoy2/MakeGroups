using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Models;

namespace WebService.Services
{
    public interface ITeamsService
    {
        IEnumerable<TeamViewModel> SplitUsersToGroup(int numberOfTeams);
    }
}
