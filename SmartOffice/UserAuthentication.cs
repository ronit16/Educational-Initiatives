using System.Collections.Generic;

namespace SmartOffice
{
    public class UserAuthentication
    {
        private Dictionary<string, string> _users;

        public UserAuthentication()
        {
            _users = new Dictionary<string, string>
            {
                { "admin", "password123" },
                { "user1", "passw0rd" }
            };
        }

        public bool Authenticate(string username, string password)
        {
            return _users.TryGetValue(username, out string storedPassword) && storedPassword == password;
        }
    }
}
