using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BlogApp.API.Swagger.Configurations;

/// <summary>
/// Configures the Swagger generator options with API version information and OpenAPI metadata.
/// </summary>
public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigureSwaggerGenOptions"/> class.
    /// </summary>
    /// <param name="apiVersionDescriptionProvider"></param>
    public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        => _apiVersionDescriptionProvider = apiVersionDescriptionProvider;

    /// <summary>
    /// Configures the Swagger generator options with API version information and OpenAPI metadata.
    /// </summary>
    /// <param name="options"></param>
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateOpenApiInfo(description));
        }
    }

    private static OpenApiInfo CreateOpenApiInfo(ApiVersionDescription description)
    {
        var info = new OpenApiInfo()
        {
            Title = "BlogApp Api",
            Version = description.ApiVersion.ToString(),
            Description = "Post your blog and also find out the interesting ones.",
            Contact = new OpenApiContact
            {
                Email = "BlogApp@gmail.com",
                Name = "BlogApp",
                Url = new Uri("https://BlogApp.com")
            }
        };

        if (description.IsDeprecated)
        {
            info.Description += " (deprecated)";
        }

        return info;
    }
}
