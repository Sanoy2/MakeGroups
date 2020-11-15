using Domain.Models;

namespace WebService.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public bool IsHighlighted { get; set; }

        protected UserViewModel()
        {

        }

        public UserViewModel(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }

        public static UserViewModel FromUser(User user)
        {
            UserViewModel userViewModel = new UserViewModel(user.Name, user.Id);

            return userViewModel;
        }

        public void Highlight()
        {
            this.IsHighlighted = true;
        }
    }
}
