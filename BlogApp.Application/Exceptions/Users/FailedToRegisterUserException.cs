namespace BlogApp.Application.Exceptions.Users;

public class FailedToRegisterUserException : BadRequestException
{
    public FailedToRegisterUserException(string message) 
        : base(message)
    {
    }
}
