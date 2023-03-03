namespace SchoolHashing;
public class User
{
    public string Username { get; private set; }
    public string HashedPassword { get; private set; }


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
