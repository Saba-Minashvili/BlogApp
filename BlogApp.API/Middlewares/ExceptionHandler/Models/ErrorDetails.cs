using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Middlewares.ExceptionHandler.Models;

/// <summary>
/// Represents the details of an error response returned by the API.
/// </summary>
public class ErrorDetails : ProblemDetails
{
    /// <summary>
    /// Gets the unique trace ID associated with this error response.
    /// </summary>
    public Guid TraceId { get; } = Guid.NewGuid();

    /// <summary>
    /// Property for exception inner message.
    /// </summary>
    public string InnerDetail { get; set; }
}
