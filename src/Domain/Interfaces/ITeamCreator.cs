using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ITeamCreator
    {
        IEnumerable<Team> Create(IEnumerable<User> users, int numberOfTeams);
    }
}
