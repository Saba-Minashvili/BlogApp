using BlogApp.Application.Authentication.JwtHelper;
using BlogApp.Application.Authentication.Models.Requests;
using BlogApp.Application.Authentication.Models.Responses;
using BlogApp.Application.Exceptions.Authentications;
using BlogApp.Domain.Users;
using BlogApp.Infrastructure;
using BlogApp.Shared.Hasher;
using BlogApp.Shared.Localizations.Culture.Resources;
using System.Security.Authentication;

namespace BlogApp.Application.Authentication;

public class UserAuthentication : IUserAuthentication
{
    private readonly IJwtHelperService _jwtHelperService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserAuthentication(IJwtHelperService jwtHelperService, IUnitOfWork unitOfWork, IPasswordHasher<User> passwordHasher)
    {
        _jwtHelperService = jwtHelperService;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest authenticationRequest, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        ArgumentNullException.ThrowIfNull(authenticationRequest, nameof(authenticationRequest));

        var user = await _unitOfWork.UserRepository.GetByEmailAsync(authenticationRequest.Email, cancellationToken) ?? throw new InvalidCredentialsException(ErrorMessages.InvalidCredentialsException);

        var verifyPasswordResult = _passwordHasher.VerifyPassword(user, user.Password, authenticationRequest.Password);

        if (!verifyPasswordResult)
            throw new InvalidCredentialsException(ErrorMessages.InvalidCredentialsException);

        var token = await _jwtHelperService.CreateTokenAsync(user.Id, user.Email);

        return token ?? throw new FailedToGenerateAccessTokenException(ErrorMessages.FailedToGenerateAccessTokenException);
    }
}