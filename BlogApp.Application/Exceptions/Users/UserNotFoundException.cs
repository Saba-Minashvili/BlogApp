namespace BlogApp.Application.Exceptions.Users;

public sealed class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string message)
        : base(message)
    {
    }
}
