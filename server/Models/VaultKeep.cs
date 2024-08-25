namespace keepr.Models;

public class VaultKeep : RepoItem<int>
{
    public int keepId { get; set; } 
    public int vaultId { get; set; }
    public string creatorId { get; set; }
}