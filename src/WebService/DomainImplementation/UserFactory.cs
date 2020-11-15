using Domain.Interfaces;
using Domain.Models;
using System;

namespace WebService.DomainImplementation
{
    public class UserFactory : IUserFactory
    {
        public User Create(string userNameWithDomain)
        {
            User user = new User(userNameWithDomain);

            return user; 
        }
    }
}
