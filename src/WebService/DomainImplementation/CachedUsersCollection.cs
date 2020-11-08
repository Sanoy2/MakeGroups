using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebService.DomainImplementation
{
    public class CachedUsersCollection : IUsersCollection
    {
        private IMemoryCache cache;

        private string cacheKey => nameof(IUsersCollection);

        private HashSet<User> users => this.GetFromCache();

        public CachedUsersCollection(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public void Add(User user)
        {
            var users = this.users;

            users.Add(user);

            this.SaveInCache(users);
        }

        public void Clear()
        {
            var newCollection = new HashSet<User>();

            this.SaveInCache(newCollection);
        }

        public IEnumerable<User> Get()
        {
            return this.users.ToList();
        }

        public void Remove(User user)
        {
            var users = this.users;

            users.Remove(user);

            this.SaveInCache(users);
        }

        private HashSet<User> GetFromCache()
        {
            var usersCollection = this.cache.Get<HashSet<User>>(this.cacheKey);
            if (usersCollection is null)
            {
                usersCollection = new HashSet<User>();
            }

            usersCollection.Add(new User("domain\\John"));
            usersCollection.Add(new User("domain\\Pablo"));
            usersCollection.Add(new User("domain\\Skyler"));
            usersCollection.Add(new User("domain\\Joey"));
            usersCollection.Add(new User("domain\\Ross"));
            usersCollection.Add(new User("domain\\Chandler"));

            return usersCollection;
        }

        private void SaveInCache(HashSet<User> usersCollection)
        {
            this.cache.Set<HashSet<User>>(this.cacheKey, usersCollection, DateTime.UtcNow.AddMinutes(60));
        }
    }
}
