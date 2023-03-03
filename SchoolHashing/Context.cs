using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SchoolHashing;
public class Context
{
    private HashSet<User> _users = new();

    private string _filePath = "Users.txt";

    public User? Login(string username, string password)
    {
        foreach (var u in _users)
        {
            string foundPassword = Hasher.HashAndSalt(password, Convert.FromBase64String(new string(u.HashedPassword[..44].Select(s => s).ToArray())));

        }
        return _users.SingleOrDefault(x => x.Username == username && x.HashedPassword == Hasher.HashAndSalt(password, Convert.FromBase64String(new string(x.HashedPassword[..44].Select(s => s).ToArray()))));
    }

    public bool Registrate(string username, string password)
    {
        if (_users.Any(x => x.Username == username))
            return false;
        _users.Add(User.RegistrateUser(username, password));
        return true;
    }

}
