namespace BlogApp.Application.Exceptions.Authentications;

public sealed class InvalidCredentialsException : BadRequestException
{
    public InvalidCredentialsException(string message) 
        : base(message)
    {
    }
}
