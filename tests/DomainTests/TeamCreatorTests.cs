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
    }
}
