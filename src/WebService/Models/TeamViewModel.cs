using System.Collections.Generic;

namespace WebService.Models
{
    public class TeamViewModel
    {
        public string Name { get; set; }

        public IList<UserViewModel> Users { get; set; }

        public TeamViewModel()
        {
            this.Users = new List<UserViewModel>();
        }
    }
}
