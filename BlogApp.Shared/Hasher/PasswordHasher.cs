using System.Security.Cryptography;


namespace BlogApp.Shared.Hasher;

public class PasswordHasher<TUser> : IPasswordHasher<TUser>
    where TUser : class
{
    private const int SaltSize = 16; // 128-bit salt

    public string HashPassword(TUser user, string password)
    {
        // Generate a random salt
        byte[] salt = new byte[SaltSize];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        // Compute the hash of the password and salt using the SHA256 algorithm
        byte[] hash = ComputeHash(password, salt);

        // Combine the salt and hash into a single string for storage
        string hashedPassword = Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);

        return hashedPassword;
    }

    public bool VerifyPassword(TUser user, string hashedPassword, string providedPassword)
    {
        // Split the stored password into its components
        string[] parts = hashedPassword.Split(':');
        byte[] salt = Convert.FromBase64String(parts[0]);
        byte[] storedHash = Convert.FromBase64String(parts[1]);

        // Compute the hash of the provided password and salt using the SHA256 algorithm
        byte[] computedHash = ComputeHash(providedPassword, salt);

        // Compare the computed hash with the stored hash
        bool passwordsMatch = storedHash.Length == computedHash.Length;
        for (int i = 0; i < storedHash.Length && passwordsMatch; i++)
        {
            passwordsMatch = storedHash[i] == computedHash[i];
        }

        return passwordsMatch;
    }

    private static byte[] ComputeHash(string password, byte[] salt)
    {
        // Concatenate the password and salt into a single byte array
        byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
        byte[] saltedPasswordBytes = new byte[passwordBytes.Length + salt.Length];
        passwordBytes.CopyTo(saltedPasswordBytes, 0);
        salt.CopyTo(saltedPasswordBytes, passwordBytes.Length);

        // Compute the hash of the salted password using the SHA256 algorithm
        using (var sha256 = SHA256.Create())
        {
            return sha256.ComputeHash(saltedPasswordBytes);
        }
    }
}
