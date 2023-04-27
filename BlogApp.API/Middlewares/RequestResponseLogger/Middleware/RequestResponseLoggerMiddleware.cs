using BlogApp.API.Middlewares.RequestResponseLogger.Models;
using System.Text;

namespace BlogApp.API.Middlewares.RequestResponseLogger.Middleware;


/// <summary>
/// Middleware for logging HTTP requests and responses.
/// </summary>
public class RequestResponseLoggerMiddleware : IMiddleware
{
    private readonly ILogger<RequestResponseLoggerMiddleware> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="RequestResponseLoggerMiddleware"/> class
    /// with the specified logger.
    /// </summary>
    /// <param name="logger"></param>
    public RequestResponseLoggerMiddleware(ILogger<RequestResponseLoggerMiddleware> logger) => _logger = logger;

    /// <summary>
    /// Logs the HTTP request and response.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/> for the current request.</param>
    /// <param name="next">The next middleware delegate.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await LogRequestAsync(context.Request);

        var originalBodyStream = context.Response.Body;
        await using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        try
        {
            await next(context);
        }
        finally
        {
            try
            {
                await LogResponseAsync(context.Response);

                await responseBody.CopyToAsync(originalBodyStream);
            }
            finally
            {
                context.Response.Body = originalBodyStream;
            }
        }
    }

    private static async Task<string> ReadRequestBodyAsync(HttpRequest request)
    {
        request.EnableBuffering();

        var buffer = new byte[request.ContentLength ?? 0];

        await request.Body.ReadAsync(buffer);

        var bodyAsText = Encoding.UTF8.GetString(buffer);

        request.Body.Position = 0;

        return bodyAsText;
    }

    private async Task LogRequestAsync(HttpRequest request)
    {
        var requestDetails = new RequestDetails
        {
            IP = request.HttpContext.Connection.RemoteIpAddress.ToString(),
            Schema = request.Scheme,
            Host = request.Host.ToString(),
            Method = request.Method,
            Path = request.Path,
            IsSecured = request.IsHttps,
            QueryString = request.QueryString.ToString(),
            Body = await ReadRequestBodyAsync(request),
        };

        var toLog = $"{Environment.NewLine}" +
                $"REQUEST - {Environment.NewLine}" +
                $"Time = {requestDetails.RequestTime} {Environment.NewLine}" +
                $"IP = {requestDetails.IP} {Environment.NewLine}" +
                $"Address = {requestDetails.Schema} {Environment.NewLine}" +
                $"Method = {requestDetails.Method} {Environment.NewLine}" +
                $"Path = {requestDetails.Path} {Environment.NewLine}" +
                $"IsSecured = {requestDetails.IsSecured} {Environment.NewLine}" +
                $"QueryString = {requestDetails.QueryString} {Environment.NewLine}" +
                $"RequestBody = {requestDetails.Body} {Environment.NewLine}";

        _logger.LogInformation(toLog);
    }

    private static async Task<string> ReadResponseBodyAsync(HttpResponse response)
    {
        var bodyAsttext = await new StreamReader(response.Body).ReadToEndAsync();

        response.Body.Seek(0, SeekOrigin.Begin);

        return bodyAsttext;
    }

    private async Task LogResponseAsync(HttpResponse response)
    {
        var responseDetails = new ResponseDetails
        {
            Body = await ReadResponseBodyAsync(response),
        };

        var toLog = $"{Environment.NewLine}" +
                $"RESPONSE - {Environment.NewLine}" +
                $"Time = {responseDetails.ResponseTime} {Environment.NewLine}" +
                $"ResponseBody = {responseDetails.Body} {Environment.NewLine}";

        _logger.LogInformation(toLog);
    }
}
