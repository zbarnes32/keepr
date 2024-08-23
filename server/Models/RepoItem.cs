namespace keepr.Models;

public abstract class RepoItem<T>
{
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}
