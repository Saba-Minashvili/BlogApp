using BlogApp.Infrastructure.Users;
using BlogApp.Persistence.Context;

namespace BlogApp.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly BlogAppDbContext _context;

    public UnitOfWork(BlogAppDbContext context)
    {
        _context = context;
        UserRepository = new UserRepository(context);
    }

    public IUserRepository UserRepository { get; }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); _context.Dispose();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
