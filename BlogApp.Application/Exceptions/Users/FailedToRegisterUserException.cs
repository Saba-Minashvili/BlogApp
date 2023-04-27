namespace BlogApp.Application.Exceptions.Users;

public sealed class FailedToRegisterUserException : BadRequestException
{
    public FailedToRegisterUserException(string message) 
        : base(message)
    {
    }
}
