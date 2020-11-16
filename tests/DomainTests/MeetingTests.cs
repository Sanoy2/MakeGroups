using Domain.Models;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DomainTests
{
    public class MeetingTests
    {
        private Meeting EmptyMeeting()
        {
            return new Meeting("some name");
        }

        [Fact]
        public void WhenUserIsLeader_WhenAddedAsMember_NoLongerIsLeader()
        {
            Meeting meeting = this.EmptyMeeting();
            User user = new User("domain\\user");
            meeting.AddLeader(user);

            meeting.AddMember(user);

            meeting.Members.Should().Contain(user);
            meeting.Leaders.Should().NotContain(user);
        }

        [Fact]
        public void WhenUserIsMember_WhenAddedAsLeader_NoLongerIsMember()
        {
            Meeting meeting = this.EmptyMeeting();
            User user = new User("domain\\user");
            meeting.AddMember(user);

            meeting.AddLeader(user);

            meeting.Leaders.Should().Contain(user);
            meeting.Members.Should().NotContain(user);
        }

        [Fact]
        public void WhenUserAdded5TimesAsMember_MeetingContainsOnly1Member()
        {
            Meeting meeting = this.EmptyMeeting();
            User user = new User("domain\\user");

            for (int i = 0; i < 5; i++)
            {
                meeting.AddMember(user);
            }

            meeting.Members.Should().Contain(user);
            meeting.Members.Should().ContainSingle();
        }

        [Fact]
        public void WhenUserAdded5TimesAsLeader_MeetingContainsOnly1Leader()
        {
            Meeting meeting = this.EmptyMeeting();
            User user = new User("domain\\user");

            for (int i = 0; i < 5; i++)
            {
                meeting.AddLeader(user);
            }

            meeting.Leaders.Should().Contain(user);
            meeting.Leaders.Should().ContainSingle();
        }

        [Fact]
        public void WhenNoLeadersAndMembers_TeamsShouldBeEmpty()
        {
            Meeting meeting = this.EmptyMeeting();

            IEnumerable<Team> teams = meeting.Teams;

            teams.Should().BeEmpty();
        }

        [Fact]
        public void WhenNoLeadersAndMembers_ArrangeTeams_TeamsShouldBeEmpty()
        {
            Meeting meeting = this.EmptyMeeting();

            meeting.ArrangeTeams();
            IEnumerable<Team> teams = meeting.Teams;

            teams.Should().BeEmpty();
        }

        [Fact]
        public void WhenOneMemberAndNoLeader_ArrangeTeams_TeamsShouldBeEmpty()
        {
            Meeting meeting = this.EmptyMeeting();
            User user = new User("domain\\user");
            meeting.AddMember(user);

            IEnumerable<Team> teams = meeting.Teams;

            teams.Should().BeEmpty();
        }

        [Fact]
        public void WhenOneLeaderAndNoMembers_ArrangeTeams_ShouldBe1Team()
        {
            Meeting meeting = this.EmptyMeeting();
            User user = new User("domain\\user");
            meeting.AddLeader(user);

            meeting.ArrangeTeams();
            IEnumerable<Team> teams = meeting.Teams;

            teams.Should().HaveCount(1);
            teams.Single().Users.Should().HaveCount(0);
            teams.Single().Leader.Should().Be(user);
        }

        [Fact]
        public void WhenOneMemberAndOneLeader_ArrangeTeams_TeamsShouldContain2Users()
        {
            Meeting meeting = this.EmptyMeeting();
            User user1 = new User("domain\\user1");
            User user2 = new User("domain\\user2");
            meeting.AddLeader(user1);
            meeting.AddMember(user2);

            meeting.ArrangeTeams();
            IEnumerable<Team> teams = meeting.Teams;

            teams.Should().HaveCount(1);
            teams.Single().Users.Should().HaveCount(1);
            teams.Single().Users.Should().Contain(user2);
            teams.Single().Leader.Should().Be(user1);
        }
    }
}
