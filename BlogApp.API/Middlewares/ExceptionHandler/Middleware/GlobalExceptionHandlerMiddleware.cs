using BlogApp.API.Middlewares.ExceptionHandler.Models;
using BlogApp.Application.Exceptions;
using BlogApp.Shared.Localizations.Culture.Resources;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace BlogApp.API.Middlewares.ExceptionHandler.Middleware;

/// <summary>
/// Global Exception Handler Middleware to handle exceptions thrown during the processing
/// of HTTP requests.
/// </summary>
public class GlobalExceptionHandlerMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalExceptionHandlerMiddleware"/> class
    /// with the specified logger.
    /// </summary>
    /// <param name="logger"></param>
    public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger) => _logger = logger;

    /// <summary>
    /// Invokes the middleware.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <param name="next">the next middleware in the pipeline.</param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var errorTitle = ErrorTitles.Exception;

            if (ex is OperationCanceledException)
            {
                errorTitle = ErrorTitles.OperationCanceledException;
                context.Response.StatusCode = 499;
            }
            else if (ex is HttpRequestException)
            {
                errorTitle = ErrorTitles.HttpRequestException;
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (ex is WebException)
            {
                errorTitle = ErrorTitles.WebException;
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (ex is NullReferenceException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorTitle = ErrorTitles.NullReferenceException;
            }
            else if (ex is UnauthorizedAccessException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                errorTitle = ErrorTitles.UnauthorizedAccessException;
            }
            else if (ex is ValidationException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorTitle = ErrorTitles.ValidationException;
            }
            else if (ex is ArgumentNullException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorTitle = ErrorTitles.ArgumentNullException;
            }
            else if (ex is InvalidDataException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                errorTitle = ErrorTitles.InvalidDataException;
            }
            else if (ex is NotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                errorTitle = ErrorTitles.NotFoundException;
            }
            else if (ex is BadRequestException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorTitle = ErrorTitles.BadRequestException;
            }
            else if (ex is ConflictException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                errorTitle = ErrorTitles.ConflictException;
            }

            await HandleExceptionAsync(context, ex, errorTitle);
        }
    }

    /// <summary>
    /// Handles the exception.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <param name="e">The exception.</param>
    /// <param name="errorTitle">The error title.</param>
    private async Task HandleExceptionAsync(HttpContext context, Exception e, string errorTitle)
    {
        var referenceToProblem = context.Response.StatusCode switch
        {
            (int)HttpStatusCode.BadRequest => "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.1",
            (int)HttpStatusCode.NotFound => "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.4",
            (int)HttpStatusCode.Unauthorized => "https://www.rfc-editor.org/rfc/rfc7235#section-3.1",
            _ => "https://www.rfc-editor.org/rfc/rfc7231#section-6.6.1",
        };

        var errorDetails = new ErrorDetails
        {
            Status = context.Response.StatusCode,
            Type = $"{e.GetType()}",
            Title = errorTitle,
            Detail = e.Message,
            Instance = referenceToProblem,
        };

        if (e.InnerException != null)
        {
            errorDetails.InnerDetail = GetLastInnerExMessage(e);
        }

        var json = JsonSerializer.Serialize(errorDetails);

        _logger.LogError(json);

        await context.Response.WriteAsync(json);
    }

    /// <summary>
    /// Recursively retrieves the message of the last inner exception in a given exception.
    /// </summary>
    /// <param name="ex">The exception to retrieve the last inner exception message from.</param>
    /// <returns>The message of the last inner exception in the given exception.</returns>
    public static string GetLastInnerExMessage(Exception ex)
    {
        if (ex.InnerException == null)
        {
            return ex.Message;
        }

        return GetLastInnerExMessage(ex.InnerException).ToString();
    }
}
