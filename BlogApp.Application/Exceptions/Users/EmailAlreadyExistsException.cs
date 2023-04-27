namespace BlogApp.Application.Exceptions.Users;

public sealed class EmailAlreadyExistsException : ConflictException
{
    public EmailAlreadyExistsException(string message) 
        : base(message)
    {
    }
}
