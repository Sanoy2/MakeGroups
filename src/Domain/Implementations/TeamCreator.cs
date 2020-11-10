using CommonUtilsToolsHelperManager.Extensions;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Implementations
{
    public class TeamCreator : ITeamCreator
    {
        public IEnumerable<Team> Create(IEnumerable<User> leaders, IEnumerable<User> members)
        {
            if(leaders is null)
            {
                throw new ArgumentNullException(nameof(leaders));
            }

            if (members is null)
            {
                throw new ArgumentNullException(nameof(members));
            }

            if (leaders.AnyElementInBothCollections(members))
            {
                throw new ArgumentException("Leader cannot be a member in the same time!");
            }

            List<Team> teams = new List<Team>();
            foreach (var leader in leaders)
            {
                Team team = new Team(leader);
                teams.Add(team);
            }

            var membersCopy = members.ToList();

            while(membersCopy.Any())
            {
                foreach (var team in teams)
                {
                    if(members.Any())
                    {
                        User member = members.Random();
                        membersCopy.Remove(member);

                        team.Add(member);
                    }
                }
            }

            return teams;
        }
    }
}
