

namespace keepr.Repositories;

public class VaultKeepsRepository
{
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
    {
       string sql = @"
       INSERT INTO
       vaultKeeps(keepId, vaultId, creatorId)
       VALUES(@KeepId, @VaultId, @CreatorId);

       SELECT 
       vaultKeeps.*
       FROM vaultKeeps
       JOIN accounts ON accounts.id = vaultKeeps.creatorId 
       WHERE vaultKeeps.id = LAST_INSERT_ID();";

        VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, vaultKeepData).FirstOrDefault();
        return vaultKeep;
    }

    internal List<VaultKeepKeep> GetKeepsInAPublicVault(int vaultId)
    {
        string sql = @"
        SELECT
        vaultKeeps.*,
        keeps.*,
        accounts.*
        FROM vaultKeeps
        JOIN keeps ON vaultKeeps.keepId = keeps.id
        JOIN accounts ON accounts.id = keeps.creatorId
        WHERE vaultId = @vaultId;";

        List<VaultKeepKeep> keeps = _db.Query<VaultKeep, VaultKeepKeep, Profile, VaultKeepKeep>(sql, (vaultKeep, keep, profile) => 
        {
            keep.VaultKeepId = vaultKeep.Id;
            keep.Creator = profile;
            return keep;
        }, new { vaultId }).ToList();

        return keeps;
    }
}

