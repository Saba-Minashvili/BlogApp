namespace BlogApp.API.Middlewares.RequestResponseLogger.Models;

/// <summary>
/// Rerpresents details of an HTTP request.
/// </summary>
public class RequestDetails
{
    /// <summary>
    /// Gets or sets the IP address of the client that sent the request.
    /// </summary>
    public string IP { get; set; }

    /// <summary>
    /// Gets or sets the URI scheme of the request, e.g. "http" or "https".
    /// </summary>
    public string Schema { get; set; }

    /// <summary>
    /// Gets or sets the host name or IP address of the server that received the request.
    /// </summary>
    public string Host { get; set; }

    /// <summary>
    /// Gets or sets the HTTP method of the request, e.g. "GET", "POST", "PUT", "DELETE", etc.
    /// </summary>
    public string Method { get; set; }

    /// <summary>
    /// Gets or sets the path component of the request URI.
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// Gets or sets the query string component of the request URI.
    /// </summary>
    public string QueryString { get; set; }

    /// <summary>
    /// Gets or sets the body of the request.
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the request was made over a secure channel.
    /// </summary>
    public bool IsSecured { get; set; }

    /// <summary>
    /// Gets the date and time when the request was made.
    /// </summary>
    public DateTime RequestTime => DateTime.Now;
}
