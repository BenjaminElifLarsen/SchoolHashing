namespace SchoolHashing;
public class User
{
    public string Username { get; set; }
    public string HashedPassword { get; set; }
    public string GetSalt => new(HashedPassword[..44].Select(s => s).ToArray());

    public User()
    {

    }

    private User(string username, string hashedPassword)
    {
        Username = username;
        HashedPassword = hashedPassword;
    }

    public static User RegistrateUser(string username, string passwordToHash)
    {
        return new(username, Hasher.HashAndSalt(passwordToHash));
    }
}
