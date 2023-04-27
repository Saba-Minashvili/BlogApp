namespace BlogApp.Application.Exceptions.Users;

public class EmailAlreadyExistsException : ConflictException
{
    public EmailAlreadyExistsException(string message) 
        : base(message)
    {
    }
}
