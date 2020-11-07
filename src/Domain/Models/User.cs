using System.Linq;

namespace Domain.Models
{
    public class User
    {
        private string userNameWithDomain;

        public string Name => this.userNameWithDomain.Split('\\').Last();
        public string Domain => this.userNameWithDomain.Split('\\').First();

        public User(string name)
        {
            this.userNameWithDomain = name;
        }

        public override bool Equals(object obj)
        {
            User otherInstance = obj as User;

            if(otherInstance is null)
            {
                return false;
            }

            return this.userNameWithDomain == otherInstance.userNameWithDomain;
        }

        public override int GetHashCode()
        {
            return this.userNameWithDomain.GetHashCode();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
