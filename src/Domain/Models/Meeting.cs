using Domain.Implementations;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Domain.Models
{
    public class Meeting
    {
        private HashSet<User> members;

        private HashSet<User> leaders;

        private IEnumerable<Team> teams;

        public IEnumerable<Team> Teams => this.teams is null ? Enumerable.Empty<Team>() : this.teams;

        public IEnumerable<User> Members => this.members.ToList();

        public IEnumerable<User> Leaders => this.leaders.ToList();

        public DateTime CreateDate { get; }

        public string Name { get; }

        public Guid Id { get; }

        public Meeting(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(name);
            }

            this.members = new HashSet<User>();
            this.leaders = new HashSet<User>();

            this.Name = name;
            this.CreateDate = DateTime.UtcNow;
            this.Id = Guid.NewGuid();
        }

        public void AddMember(User user)
        {
            this.members.Add(user);
            this.leaders.Remove(user);
        }

        public void AddLeader(User user)
        {
            this.leaders.Add(user);
            this.members.Remove(user);
        }

        public void Remove(User user)
        {
            this.members.Remove(user);
            this.leaders.Remove(user);
        }

        public IEnumerable<Team> ArrangeTeams()
        {
            ITeamCreator teamCreator = new TeamCreator();
            return this.ArrangeTeams(teamCreator);
        }

        public IEnumerable<Team> ArrangeTeams(ITeamCreator teamCreator)
        {
            var teams = teamCreator.Create(this.leaders, this.members);
            this.teams = teams;

            return teams.ToList();
        }

        public void ClearTeams()
        {
            this.teams = Enumerable.Empty<Team>();
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() * 19 + this.Name.GetHashCode() * 29;
        }

        public override bool Equals(object obj)
        {
            if(obj is null)
            {
                return false;
            }

            Meeting other = obj as Meeting;
            if(other is null)
            {
                return false;
            }

            return this.Id == other.Id;
        }
    }
}
