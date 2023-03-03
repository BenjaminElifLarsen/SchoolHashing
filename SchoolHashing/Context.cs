using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHashing;
public class Context
{
    private HashSet<User> _users = new();

    private string _filePath = "Users.txt";

    public User? Login(string username, string password)
    {
        return _users.SingleOrDefault(x => x.Username == username);
    }

    public bool Registrate(string username, string password)
    {
        if (_users.Any(x => x.Username == username))
            return false;
        _users.Add(User.RegistrateUser(username, password));
        return true;
    }

}
