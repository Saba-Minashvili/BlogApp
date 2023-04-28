namespace BlogApp.Application.Exceptions.Blogs;

public class BlogNotFoundException : NotFoundException
{
    public BlogNotFoundException(string message) 
        : base(message)
    {
    }
}
