using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Implementations
{
    public class FakeUsersCollection : IUsersCollection
    {
        private static HashSet<User> users = new HashSet<User>()
        {
            new User("aa\\Ross"),
            new User("aa\\Joey"),
            new User("aa\\Chandler"),
        };

        public void Add(User user)
        {
        }

        public void Clear()
        {
        }

        public IEnumerable<User> Get()
        {
            return users.ToList();
        }

        public void Remove(User user)
        {
        }
    }
}
