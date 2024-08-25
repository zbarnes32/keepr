


using Microsoft.AspNetCore.Http;

namespace keepr.Repositories;

public class VaultsRepository
{
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Vault CreateVault(Vault vaultData)
    {
        string sql = @"
        INSERT INTO
        vaults(name, description, img, isPrivate, creatorId)
        VALUES(@Name, @Description, @Img, @IsPrivate, @CreatorId);

        SELECT
        vaults.*,
        accounts.*
        FROM vaults
        JOIN accounts ON accounts.id = vaults.creatorId
        WHERE vaults.id = LAST_INSERT_ID();";

        Vault vault = _db.Query<Vault, Profile, Vault>(sql, 
        (vault, profile) => 
        {
            vault.Creator = profile;
            return vault;
        }, vaultData).FirstOrDefault();

        return vault;
    }

    internal void DestroyVault(int vaultId)
    {
        string sql = "DELETE FROM vaults WHERE id = @vaultId LIMIT 1;";

        int rowsAffected = _db.Execute(sql, new { vaultId });

        if(rowsAffected == 0) throw new Exception("Unable to delete.");
        if (rowsAffected > 1) throw new Exception("Deleted more than attended.");
    }

    internal Vault GetVaultById(int vaultId)
    {
        string sql = @"
        SELECT
        vaults.*,
        accounts.*
        FROM vaults
        JOIN accounts ON accounts.id = vaults.creatorId
        WHERE vaults.id = @vaultId;";

        Vault vault = _db.Query<Vault, Profile, Vault>(sql, 
        (vault, profile) => 
        {
            vault.Creator = profile;
            return vault;
        }, new { vaultId }).FirstOrDefault();

        return vault;
    }

    internal Vault UpdateVault(Vault vaultData)
    {
        string sql = @"
        UPDATE vaults
        SET
        name = @Name,
        description = @Description,
        img = @Img,
        isPrivate = @IsPrivate
        WHERE id = @Id LIMIT 1;

        SELECT
        vaults.*,
        accounts.*
        FROM vaults
        JOIN accounts ON accounts.id = vaults.creatorId
        WHERE vaults.id = @Id;";

        Vault vault = _db.Query<Vault, Profile, Vault>(sql, 
        (vault, profile) => 
        {
            vault.Creator = profile;
            return vault;
        }, vaultData).FirstOrDefault();

        return vault;
    }

    
}

