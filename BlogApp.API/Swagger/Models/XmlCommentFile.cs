using System.Reflection;

namespace BlogApp.API.Swagger.Models;

/// <summary>
/// Provides the path to the XML documentation file for the current assembly.
/// </summary>
public static class XmlCommentFile
{
    /// <summary>
    /// Gets the file path to the XML documentation file.
    /// </summary>
    public static string FilePath
    {
        get
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            return Path.Combine($"{AppContext.BaseDirectory}", xmlFile);
        }
    }
}

