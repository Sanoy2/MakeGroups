using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Implementations
{
    public class InMemoryUsersCollection : IUsersCollection
    {
        private HashSet<User> users;

        public InMemoryUsersCollection()
        {
            this.users = new HashSet<User>();
        }

        public void Add(User user)
        {
            this.users.Add(user);
        }

        public void Clear()
        {
            this.users = new HashSet<User>();
        }

        public IEnumerable<User> Get()
        {
            return this.users.ToList();
        }

        public void Remove(User user)
        {
            this.users.Remove(user);
        }
    }
}
