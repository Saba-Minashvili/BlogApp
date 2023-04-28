using BlogApp.Domain.Abstractions;
using BlogApp.Domain.Blogs;
using BlogApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogApp.Infrastructure.Blogs;

public class BlogRepository : IBlogRepository
{
    private readonly BlogAppDbContext _context;

    public BlogRepository(BlogAppDbContext context) => _context = context;

    public async Task<IEnumerable<Blog>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Blogs
            .Include(o => o.Authors)
                .ThenInclude(o => o.User)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Blog>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await _context.Blogs
            .Include(o => o.Authors)
                .ThenInclude(o => o.User)
            .Where(o => o.Authors.Select(o => o.UserId).Contains(userId))
            .ToListAsync(cancellationToken);
    }

    public async Task<Blog> GetByIdAsync(int blogId, CancellationToken cancellationToken = default)
    {
        return await _context.Blogs
            .Include(o => o.Authors)
                .ThenInclude(o => o.User)
            .FirstOrDefaultAsync(o => o.Id == blogId, cancellationToken);
    }

    public async Task CreateAsync(Blog blog, CancellationToken cancellationToken = default)
    {
        blog.CreatedAt = DateTime.Now;
        blog.ModifiedAt = DateTime.Now;
        blog.Status = nameof(EntityStatus.Active);

        await _context.Blogs.AddAsync(blog, cancellationToken);
    }

    public async Task<bool> ExistsAsync(Expression<Func<Blog, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _context.Blogs
            .AnyAsync(predicate, cancellationToken);
    }
}
