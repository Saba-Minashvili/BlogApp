namespace BlogApp.Domain.Abstractions;

public interface IEntity
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public string Status { get; set; }
}
