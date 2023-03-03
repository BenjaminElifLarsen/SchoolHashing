using System.Security.Cryptography;
namespace SchoolHashing;
public class Hasher
{
    /// <summary>
    /// Used for fully new passwords
    /// </summary>
    /// <param name="toEncode"></param>
    /// <returns></returns>
    public static string HashAndSalt(string toEncode)
    {
        return Calculation(toEncode, RandomNumberGenerator.GetBytes(32));
    }

    /// <summary>
    /// Used for comparing password where the salt is already known
    /// </summary>
    /// <param name="toEncode"></param>
    /// <param name="salt"></param>
    /// <returns></returns>
    public static string HashAndSalt(string toEncode, byte[] salt)
    {
        return Calculation(toEncode, salt);
    }

    private static string Calculation(string toEncode, byte[] salt)
    {
        string hashed = null; //implement pepper?

        using (SHA256 sha = SHA256.Create())
        {
            byte[] toHash = salt.Concat(toEncode.Select(x => (byte)x)).ToArray();
            byte[] hashArray = sha.ComputeHash(toHash);
            hashed = Convert.ToBase64String(salt) + Convert.ToBase64String(hashArray);
        }
        return hashed;
    }
}
