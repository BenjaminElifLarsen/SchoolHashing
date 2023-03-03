using System.Security.Cryptography;
namespace SchoolHashing;
internal class Hasher
{
    /// <summary>
    /// Used for fully new passwords
    /// </summary>
    /// <param name="toEncode"></param>
    /// <returns></returns>
    public static string HashAndSalt(string toEncode)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(32);
        return Calculation(toEncode, salt);
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
        string hashed = null;

        using(SHA256 sha = SHA256.Create())
        {
            byte[] hashArray = sha.ComputeHash(toEncode.Select(x => (byte)x).ToArray());
            hashed = Convert.ToBase64String(hashArray);
        }
        return hashed;
        //string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(toEncode, salt, KeyDerivationPrf.HMACSHA512, 100000, 32));
        //return Convert.ToBase64String(salt) + hashed;
    }
}
