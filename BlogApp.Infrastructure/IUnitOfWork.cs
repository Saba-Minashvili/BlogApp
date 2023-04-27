using BlogApp.Infrastructure.Users;

namespace BlogApp.Infrastructure;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
