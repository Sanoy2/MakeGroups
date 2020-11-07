using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using WebService.Models;

namespace WebService.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersCollection usersCollection;

        public UsersService(IUsersCollection usersCollection)
        {
            this.usersCollection = usersCollection;
        }

        public IEnumerable<UserViewModel> Get()
        {
            IEnumerable<UserViewModel> userViewModels = usersCollection
                                                            .Get()
                                                            .Select(x => UserViewModel.FromUser(x));

            return userViewModels;
        }

        public void Add(string domainUsername)
        {
            User user = new User(domainUsername);

            this.usersCollection.Add(user);
        }
        
        public void Remove(string domainUsername)
        {
            User user = new User(domainUsername);

            this.usersCollection.Remove(user);
        }

        public void Clear()
        {
            this.usersCollection.Clear();
        }
    }
}
