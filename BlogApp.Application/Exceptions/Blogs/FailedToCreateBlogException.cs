namespace BlogApp.Application.Exceptions.Blogs;

public class FailedToCreateBlogException : BadRequestException
{
    public FailedToCreateBlogException(string message) 
        : base(message)
    {
    }
}
