using System.Collections.Generic;
using System.Linq;

namespace Domain.Models
{
    public class Team
    {
        private HashSet<User> users;

        public string Name { get; }

        public IEnumerable<User> Users => this.users.ToList();

        public Team(string teamName)
        {
            this.Name = teamName;
            this.users = new HashSet<User>();
        }

        public void Add(User user)
        {
            this.users.Add(user);
        }
    }
}
