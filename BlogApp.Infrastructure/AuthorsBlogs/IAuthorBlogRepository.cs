using BlogApp.Domain.AuthorsBlogs;

namespace BlogApp.Infrastructure.AuthorsBlogs;

public interface IAuthorBlogRepository
{
    Task<AuthorBlog> GetAuthorBlogByBlogIdAsync(int blogId, CancellationToken cancellationToken = default);

    Task DeleteAuthorBlog(int blogId, CancellationToken cancellationToken = default);
}
