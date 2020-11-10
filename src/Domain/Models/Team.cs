using System.Collections.Generic;
using System.Linq;

namespace Domain.Models
{
    public class Team
    {
        public User Leader { get; }

        private HashSet<User> users;

        public string Name { get; }

        public IEnumerable<User> Users => this.users.ToList();

        protected Team()
        {
            this.users = new HashSet<User>();
        }

        public Team(User leader) : this()
        {
            this.Leader = leader;
            this.Name = $"{leader.FullName}'s team";
        }

        public Team(string teamName, User leader) : this()
        {
            this.Name = teamName;
            this.Leader = leader;
        }

        public void Add(User user)
        {
            if(this.Leader.Equals(user) == false)
            {
                this.users.Add(user);
            }
        }
    }
}
