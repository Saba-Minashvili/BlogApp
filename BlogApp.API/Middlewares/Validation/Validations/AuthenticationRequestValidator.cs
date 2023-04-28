using BlogApp.Application.Authentication.Models.Requests;
using BlogApp.Shared.Localizations.Culture.Resources;
using FluentValidation;

namespace BlogApp.API.Middlewares.Validation.Validations;

/// <summary>
/// Represents a validator for the <see cref="AuthenticationRequestValidator"/> class.
/// </summary>
public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthenticationRequestValidator"/> class and
    /// sets up validation rules for the Email and Password properties.
    /// </summary>
    public AuthenticationRequestValidator()
    {
        RuleFor(o => o.Email)
            .NotNull()
            .WithMessage(ValidationErrorMessages.NotNull)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.NotEmpty);

        RuleFor(o => o.Password)
            .NotNull()
            .WithMessage(ValidationErrorMessages.NotNull)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.NotEmpty);
    }
}
