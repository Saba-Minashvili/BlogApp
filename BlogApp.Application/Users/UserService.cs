using BlogApp.Application.Exceptions.Users;
using BlogApp.Application.Users.Requests;
using BlogApp.Application.Users.Responses;
using BlogApp.Domain.Users;
using BlogApp.Infrastructure;
using BlogApp.Shared.Hasher;
using BlogApp.Shared.Localizations.Culture.Resources;
using Mapster;

namespace BlogApp.Application.Users;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(IUnitOfWork unitOfWork, IPasswordHasher<User> passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<IEnumerable<UserResponseModel>> GetAllUsersAsync(CancellationToken cancellationToken = default)
    {
        var users = await _unitOfWork.UserRepository.GetAllAsync(cancellationToken);

        if (!users.Any())
        {
            return Enumerable.Empty<UserResponseModel>();
        }

        return users.Adapt<IEnumerable<UserResponseModel>>();
    }

    public async Task<UserResponseModel> GetUserByIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(userId, cancellationToken) ?? throw new UserNotFoundException(ErrorMessages.UserNotFoundException);

        return user.Adapt<UserResponseModel>();
    }

    public async Task<int> RegisterUserAsync(UserRequestCreateModel request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var emailExists = await _unitOfWork.UserRepository.ExistsAsync(o => o.Email.ToLower() ==  request.Email.ToLower(), cancellationToken);

        if (emailExists)
            throw new EmailAlreadyExistsException(ErrorMessages.EmailAlreadyExistsException);

        var user = request.Adapt<User>();

        user.Password = _passwordHasher.HashPassword(user, request.Password);

        await _unitOfWork.UserRepository.CreateAsync(user, cancellationToken);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? result : throw new FailedToRegisterUserException(ErrorMessages.FailedToRegisterUserExecption);
    }
}
