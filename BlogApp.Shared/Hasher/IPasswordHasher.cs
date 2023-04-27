namespace BlogApp.Shared.Hasher;

public interface IPasswordHasher<TUser>
{
    public string HashPassword(TUser user, string password);

    public bool VerifyPassword(TUser user, string hashedPassword, string providedPassword);
}
