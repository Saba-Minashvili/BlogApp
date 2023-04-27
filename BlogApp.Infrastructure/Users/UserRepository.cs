using BlogApp.Domain.Abstractions;
using BlogApp.Domain.Users;
using BlogApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogApp.Infrastructure.Users;

public class UserRepository : IUserRepository
{
    private readonly BlogAppDbContext _context;

    public UserRepository(BlogAppDbContext dbContext) => _context = dbContext;

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Users
            .ToListAsync(cancellationToken);
    }

    public async Task<User> GetByIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await _context.Users
            .FirstOrDefaultAsync(o => o.Id == userId, cancellationToken);
    }

    public async Task CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        user.CreatedAt = DateTime.Now;
        user.ModifiedAt = DateTime.Now;
        user.Status = nameof(EntityStatus.Active);

        await _context.Users.AddAsync(user, cancellationToken);
    }

    public async Task<bool> ExistsAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _context.Users
            .AnyAsync(predicate, cancellationToken);
    }
}
