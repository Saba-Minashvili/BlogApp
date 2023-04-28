using BlogApp.Domain.Blogs;
using System.Linq.Expressions;

namespace BlogApp.Infrastructure.Blogs;

public interface IBlogRepository
{
    Task<IEnumerable<Blog>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<Blog>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default);

    Task<Blog> GetByIdAsync(int blogId, CancellationToken cancellationToken = default);

    Task CreateAsync(Blog blog, CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(Expression<Func<Blog, bool>> predicate, CancellationToken cancellationToken = default);
}
