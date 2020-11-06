namespace WebService.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }

        public UserViewModel()
        {

        }

        public UserViewModel(string name)
        {
            this.Name = name;
        }
    }
}
