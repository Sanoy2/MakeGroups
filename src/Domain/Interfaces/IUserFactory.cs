using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserFactory
    {
        User Create(string userNameWithDomain);
    }
}
