using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IUsersCollection
    {
        void Add(User user);

        void Remove(User user);

        IEnumerable<User> Get();

        void Clear();
    }
}
