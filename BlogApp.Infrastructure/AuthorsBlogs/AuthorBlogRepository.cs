using BlogApp.Domain.AuthorsBlogs;
using BlogApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Infrastructure.AuthorsBlogs;

public class AuthorBlogRepository : IAuthorBlogRepository
{
    private readonly BlogAppDbContext _context;

    public AuthorBlogRepository(BlogAppDbContext context) => _context = context;

    public async Task<AuthorBlog> GetAuthorBlogByBlogIdAsync(int blogId, CancellationToken cancellationToken = default)
    {
        return await _context.AuthorBlogs
            .FirstOrDefaultAsync(o => o.BlogId == blogId, cancellationToken);
    }

    public async Task DeleteAuthorBlog(int blogId, CancellationToken cancellationToken = default)
    {
        var blog = await GetAuthorBlogByBlogIdAsync(blogId, cancellationToken);

        _context.AuthorBlogs.Remove(blog);
    }
}
