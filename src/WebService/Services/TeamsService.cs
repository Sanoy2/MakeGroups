using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using WebService.Models;

namespace WebService.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly IUsersCollection usersService;
        private readonly ITeamCreator teamCreator;

        public TeamsService(IUsersCollection usersCollection, ITeamCreator teamCreator)
        {
            this.usersService = usersCollection;
            this.teamCreator = teamCreator;
        }

        public IEnumerable<TeamViewModel> SplitUsersToGroup(int numberOfTeams)
        {
            //var users = this.usersService.Get();

            //var teams = this.teamCreator.Create(users, numberOfTeams);

            //var teamsModels = teams.Select(x => TeamViewModel.FromTeam(x));

            //return teamsModels;

            throw new NotImplementedException();
        }
    }
}
