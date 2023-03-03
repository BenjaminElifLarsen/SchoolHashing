using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SchoolHashing;
public class Context
{
    private bool _saveData;
    private HashSet<User> _users = new();

    private string _filePath = "DataContext.txt";

    public Context(bool Save = true)
    {
        _saveData = Save;
    }

    public User? Login(string username, string password)
    {
        if(!_saveData)
            return _users.SingleOrDefault(x => x.Username == username && x.HashedPassword == Hasher.HashAndSalt(password, Convert.FromBase64String(x.GetSalt)));
        return GetUsersFromFile().SingleOrDefault(x => x.Username == username && x.HashedPassword == Hasher.HashAndSalt(password, Convert.FromBase64String(x.GetSalt)));
    }

    public bool Registrate(string username, string password)
    {
        if (!_saveData && _users.Any(x => x.Username == username))
            return false;
        else if(_saveData)
        {
            if (GetUserFromFile(username) != null) return false;
        }
        var user = User.RegistrateUser(username, password);
        if(!_saveData) _users.Add(user);
        if(_saveData) SaveUser(user);
        return true;
    }

    private User? GetUserFromFile(string username)
    {
        return GetUsersFromFile().SingleOrDefault(x => x.Username == username);
    }

    private IEnumerable<User> GetUsersFromFile()
    {
        List<User> users = new();

        string[] contextData = File.ReadAllLines(_filePath);
        foreach (var u in contextData)
        {
            User us = JsonSerializer.Deserialize<User>(u);
            users.Add(us);
        }
        return users;
    }

    private void SaveUser(User entity)
    {
        StringBuilder sb = new();
        sb.Append("{");
        sb.Append($"\"{nameof(entity.Username)}\" : \"{entity.Username}\"");
        sb.Append(',');
        sb.Append($"\"{nameof(entity.HashedPassword)}\" : \"{entity.HashedPassword}\"");
        sb.Append('}');
        using StreamWriter file = new(_filePath, append: true);
        file.WriteLine(sb.ToString());
    }

}
