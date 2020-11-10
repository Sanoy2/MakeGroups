using System.Linq;

namespace Domain.Models
{
    public class User
    {
        private string userNameWithDomain;

        public string Name => this.userNameWithDomain.Split('\\').Last();

        public string Domain => this.userNameWithDomain.Split('\\').First();

        public string FullName { get; }

        public User(string name)
        {
            this.userNameWithDomain = name;
            this.FullName = string.Empty;
        }

        public User(string userNameWithDomain, string fullName)
        {
            this.userNameWithDomain = userNameWithDomain;
            this.FullName = fullName;
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
