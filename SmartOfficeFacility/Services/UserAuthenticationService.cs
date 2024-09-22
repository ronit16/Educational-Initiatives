using System.Collections.Generic;

public class UserAuthenticationService : IUserAuthentication
{
    private Dictionary<string, string> users;

    public UserAuthenticationService()
    {
        users = new Dictionary<string, string>
        {
            { "admin", "password" } // Example user
        };
    }

    public bool Authenticate(string username, string password)
    {
        return users.TryGetValue(username, out var storedPassword) && storedPassword == password;
    }
}
