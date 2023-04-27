using BlogApp.Domain.Abstractions;
using BlogApp.Domain.AuthorsBlogs;

namespace BlogApp.Domain.Users;

public class User : IEntity
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public ICollection<AuthorBlog> Blogs { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public string Status { get; set; }
}
