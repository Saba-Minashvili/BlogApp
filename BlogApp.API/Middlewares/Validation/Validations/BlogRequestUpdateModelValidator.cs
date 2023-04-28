using BlogApp.Application.Blogs.Requests;
using BlogApp.Shared.Localizations.Culture.Resources;
using FluentValidation;

namespace BlogApp.API.Middlewares.Validation.Validations;

/// <summary>
/// Represents a validator for the <see cref="BlogRequestUpdateModel"/> class.
/// </summary>
public class BlogRequestUpdateModelValidator : AbstractValidator<BlogRequestUpdateModel>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BlogRequestCreateModelValidator"/> class and
    /// sets up validation rules for the Title and Description properties.
    /// </summary>
    public BlogRequestUpdateModelValidator()
    {
        RuleFor(o => o.Title)
            .NotNull()
            .WithMessage(ValidationErrorMessages.NotNull)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.NotEmpty)
            .Matches("^[a-zA-Z0-9,.\\-_\"' ]+$")
            .WithMessage(ValidationErrorMessages.Title)
            .MinimumLength(2)
            .WithMessage(ValidationErrorMessages.MinimumLength)
            .MaximumLength(50)
            .WithMessage(ValidationErrorMessages.MaximumLength);

        RuleFor(o => o.Description)
            .NotNull()
            .WithMessage(ValidationErrorMessages.NotNull)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.NotEmpty)
            .Matches(@"^[a-zA-Z0-9 _-]+")
            .WithMessage(ValidationErrorMessages.Description)
            .MinimumLength(2)
            .WithMessage(ValidationErrorMessages.MinimumLength);
    }
}
