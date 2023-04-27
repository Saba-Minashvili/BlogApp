namespace BlogApp.Application.Exceptions.Authentications;

public class FailedToGenerateAccessTokenException : BadRequestException
{
    public FailedToGenerateAccessTokenException(string message) 
        : base(message)
    {
    }
}
