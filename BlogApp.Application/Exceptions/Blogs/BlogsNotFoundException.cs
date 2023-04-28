namespace BlogApp.Application.Exceptions.Blogs;

public class BlogsNotFoundException : NotFoundException
{
    public BlogsNotFoundException(string message) 
        : base(message)
    {
    }
}
