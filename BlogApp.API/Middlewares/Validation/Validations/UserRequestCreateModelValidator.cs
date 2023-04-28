using BlogApp.Application.Users.Requests;
using BlogApp.Shared.Localizations.Culture.Resources;
using FluentValidation;

namespace BlogApp.API.Middlewares.Validation.Validations;

/// <summary>
/// Represents a validator for the <see cref="UserRequestCreateModel"/> class.
/// </summary>
public class UserRequestCreateModelValidator : AbstractValidator<UserRequestCreateModel>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserRequestCreateModelValidator"/> class and
    /// sets up validation rules for the Firstname, Lastname, Email and Password properties.
    /// </summary>
    public UserRequestCreateModelValidator()
    {
        RuleFor(o => o.FirstName)
            .NotNull()
            .WithMessage(ValidationErrorMessages.NotNull)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.NotEmpty)
            .Matches("^[a-zA-Z- ]*$")
            .WithMessage(ValidationErrorMessages.Name)
            .MinimumLength(2)
            .WithMessage(ValidationErrorMessages.MinimumLength)
            .MaximumLength(50)
            .WithMessage(ValidationErrorMessages.MaximumLength);

        RuleFor(o => o.LastName)
            .NotNull()
            .WithMessage(ValidationErrorMessages.NotNull)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.NotEmpty)
            .Matches("^[a-zA-Z- ]*$")
            .WithMessage(ValidationErrorMessages.Name)
            .MinimumLength(2)
            .WithMessage(ValidationErrorMessages.MinimumLength)
            .MaximumLength(50)
            .WithMessage(ValidationErrorMessages.MaximumLength);

        RuleFor(o => o.Email)
           .NotEmpty()
           .WithMessage(ValidationErrorMessages.NotEmpty)
           .EmailAddress()
           .WithMessage(ValidationErrorMessages.Email);

        RuleFor(p => p.Password)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.NotEmpty)
            .MinimumLength(8)
            .WithMessage(ValidationErrorMessages.MinimumLength)
            .MaximumLength(50)
            .WithMessage(ValidationErrorMessages.MaximumLength)
            .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\w\\d\\s:])(?!.*\\s).*$")
            .WithMessage(ValidationErrorMessages.Password);
    }
}
