using CommonUtilsToolsHelperManager.Extensions;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Implementations
{
    public class TeamCreator : ITeamCreator
    {
        private string[] greekLetters = new string[] { "α", "β", "γ", "δ", "ε", "θ", "λ", "ξ", "π", "φ", "ψ", "ω"};

        private Random random;

        public TeamCreator()
        {
            this.random = new Random();
        }

        public IEnumerable<Team> Create(IEnumerable<User> users, int numberOfTeams)
        {
            if(users is null)
            {
                throw new ArgumentNullException(nameof(users));
            }

            if(numberOfTeams > users.Count())
            {
                numberOfTeams = users.Count();
            }

            if(numberOfTeams < 1)
            {
                throw new ArgumentException($"You cannot create fewer than 1 team!");
            }

            if(numberOfTeams > this.greekLetters.Length)
            {
                throw new ArgumentException($"You can create not more than {this.greekLetters.Length} teams!");
            }

            var teams = new List<Team>();

            for (int i = 0; i < numberOfTeams; i++)
            {
                teams.Add(new Team(this.greekLetters[i]));
            }

            var usersCopy = users.ToList();

            while(usersCopy.Any())
            {
                for (int i = 0; i < numberOfTeams && usersCopy.Any(); i++)
                {
                    var user = usersCopy.Random();

                    usersCopy.Remove(user);

                    Team team = teams[i];
                    team.Add(user);
                }
            }

            return teams;
        }
    }
}
