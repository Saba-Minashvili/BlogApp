using BlogApp.API.Middlewares.ExceptionHandler.Extensions;
using BlogApp.API.Middlewares.RequestResponseLogger.Extensions;
using BlogApp.API.Middlewares.Validation.Extensions;
using BlogApp.API.Swagger.Extensions;
using BlogApp.Application.Authentication.Extensions;
using BlogApp.Application.Extensions;
using BlogApp.Application.Mappings;
using BlogApp.Infrastructure.Extensions;
using BlogApp.Persistence.Extensions;
using BlogApp.Shared.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .ReadFrom.Configuration(configuration)
    .CreateBootstrapLogger();

try
{
    Log.Information("Application has been started...");

    builder.Logging.ClearProviders();
    builder.Host.UseSerilog();

    builder.Services.AddRequestResponseLogger();
    builder.Services.AddGlobalExceptionHandler();

    builder.Services.AddDatabaseContext(configuration);

    builder.Services.AddUnitOfWork();

    builder.Services.AddHttpContextAccessor();

    builder.Services.AddServices();

    builder.Services.AddValidation();
    builder.Services.AddFilters();

    builder.Services.AddJwtOptionsConfiguration(configuration);
    builder.Services.AddJwtAuthentication();
    builder.Services.AddJwtServices();

    builder.Services.AddMapster();

    builder.Services.AddPasswordHasher();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.ImplementApiVersioning();

    builder.Services.ImplementSwagger();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseCustomSwagger();
    }

    app.UseRequestLocalization("ka-GE", "en-US");

    app.UseGlobalExceptionHandler();

    app.UseRequestResponseLogger();

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "Application has been stopped because of an exception.");
}
finally
{
    Log.CloseAndFlush();
}