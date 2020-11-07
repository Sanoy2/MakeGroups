using Domain.Models;

namespace WebService.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }

        protected UserViewModel()
        {

        }

        public UserViewModel(string name)
        {
            this.Name = name;
        }

        public static UserViewModel FromUser(User user)
        {
            UserViewModel userViewModel = new UserViewModel(user.Name);

            return userViewModel;
        }
    }
}
