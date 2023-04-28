namespace BlogApp.API.Middlewares.Validation.Models;

/// <summary>
/// Represents an error associated with a field and a message.
/// </summary>
public class ErrorModel
{
    /// <summary>
    /// Gets or sets the name of the field associated with the error.
    /// </summary>
    public string FieldName { get; set; }

    /// <summary>
    /// Gets or sets the error message.
    /// </summary>
    public string Message { get; set; }
}
