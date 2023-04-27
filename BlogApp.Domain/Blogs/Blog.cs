using BlogApp.Domain.Abstractions;
using BlogApp.Domain.AuthorsBlogs;

namespace BlogApp.Domain.Blogs;

public class Blog : IEntity
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public ICollection<AuthorBlog> Authors { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public string Status { get; set; }
}
