using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Models;

namespace WebService.Services
{
    public interface IUsersService
    {
        IEnumerable<UserViewModel> Get();

        void Add(string domainUsername);

        void Remove(string domainUsername);

        void Clear();
    }
}
