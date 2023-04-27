namespace BlogApp.Application.Exceptions.Users;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string message)
        : base(message)
    {
    }
}
