using System.Globalization;

namespace BlogApp.Application.Exceptions.Users;

public class EmailNotFoundException : NotFoundException
{
    public EmailNotFoundException(string message, object arg) 
        : base(string.Format(CultureInfo.InvariantCulture, message, arg))
    {
    }
}
