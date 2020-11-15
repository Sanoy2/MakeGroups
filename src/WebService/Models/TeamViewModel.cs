using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebService.Models
{
    public class TeamViewModel
    {
        public string Name { get; set; }

        public IList<UserViewModel> Users { get; set; }

        public UserViewModel Leader { get; set; }

        public TeamViewModel()
        {
            this.Users = new List<UserViewModel>();
        }

        public static TeamViewModel FromTeam(Team team)
        {
            TeamViewModel teamViewModel = new TeamViewModel();

            teamViewModel.Name = team.Name;

            teamViewModel.Leader = UserViewModel.FromUser(team.Leader);

            teamViewModel.Users = team.Users.Select(x => UserViewModel.FromUser(x)).ToList();

            return teamViewModel;
        }
    }
}
