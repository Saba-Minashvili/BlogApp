using BlogApp.Domain.Blogs;
using BlogApp.Domain.Users;

namespace BlogApp.Domain.AuthorsBlogs;

public class AuthorBlog
{
    public int UserId { get; set; }

    public User User { get; set; }

    public int BlogId { get; set; }

    public Blog Blog { get; set; }
}
