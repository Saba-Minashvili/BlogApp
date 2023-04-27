using BlogApp.Application.Users.Requests;
using BlogApp.Application.Users.Responses;

namespace BlogApp.Application.Users;

public interface IUserService
{
    Task<IEnumerable<UserResponseModel>> GetAllUsersAsync(CancellationToken cancellationToken = default);

    Task<UserResponseModel> GetUserByIdAsync(int userId, CancellationToken cancellationToken = default);

    Task<int> RegisterUserAsync(UserRequestCreateModel request, CancellationToken cancellationToken = default);
}
