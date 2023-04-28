namespace BlogApp.Application.Blogs.Requests;

public class BlogRequestCreateModel
{
    public string Title { get; set; }

    public string Description { get; set; }

    public IEnumerable<string> Authors { get; set; }
}
