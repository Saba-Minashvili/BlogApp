namespace BlogApp.API.Middlewares.RequestResponseLogger.Models;

/// <summary>
/// Represents the details of a response.
/// </summary>
public class ResponseDetails
{
    /// <summary>
    /// Gets or sets the body of the response.
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Gets the time the response was sent.
    /// </summary>
    public DateTime ResponseTime => DateTime.Now;
}
