namespace BlogApp.Shared.Models;

public class ConnectionStringOptions
{
    public const string ConnectionStrings = nameof(ConnectionStrings);

    public string BlogAppDbConnectionString { get; set; } = string.Empty;
}
