using Domain.Implementations;
using Domain.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Configuration;
using Xunit;

namespace DomainTests
{
    public class TeamCreatorTests
    {
        private TeamCreator teamCreator;

        public TeamCreatorTests()
        {
            this.teamCreator = new TeamCreator();
        }

        [Fact]
        public void WhenNumberOfTeamIsNegative2_ShouldThrowException()
        {
            int numberOfTeams = -2;
            IEnumerable<User> users = new List<User>();
            Action act = () =>
            {
                this.teamCreator.Create(users, numberOfTeams);
            };

            act.Should().Throw<Exception>();
        }

        [Fact]
        public void WhenUsersCollectionNull_ShouldThrowException()
        {
            int numberOfTeams = 2;
            IEnumerable<User> users = null;
            Action act = () =>
            {
                this.teamCreator.Create(users, numberOfTeams);
            };

            act.Should().Throw<Exception>();
        }
    }
}
