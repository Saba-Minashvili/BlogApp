using BlogApp.Infrastructure.AuthorsBlogs;
using BlogApp.Infrastructure.Blogs;
using BlogApp.Infrastructure.Users;

namespace BlogApp.Infrastructure;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }

    IBlogRepository BlogRepository { get; }

    IAuthorBlogRepository AuthorBlogRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
