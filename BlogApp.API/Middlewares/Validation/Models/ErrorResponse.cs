namespace BlogApp.API.Middlewares.Validation.Models;

/// <summary>
/// Represents an error response that contains a list of <see cref="ErrorModel"/> objects.
/// </summary>
public class ErrorResponse
{
    /// <summary>
    /// Gets or sets the list of errors.
    /// </summary>
    public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
}
