


namespace keepr.Repositories;

public class ProfilesRepository
{
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Profile GetProfileById(string profileId)
    {
        string sql = @"
        SELECT
        *
        FROM accounts
        WHERE id = @ProfileId;";

        Profile profile = _db.Query<Profile>(sql, new { profileId = profileId }).FirstOrDefault();
        return profile;
    }

    internal List<Keep> GetUserKeeps(string profileId)
    {
        string sql = @"
        SELECT
        keeps.*,
        accounts.*
        FROM keeps
        JOIN accounts ON accounts.id = keeps.creatorId
        WHERE keeps.creatorId = @profileId;";

        List<Keep> myKeeps = _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
        {
            keep.Creator = profile;
            return keep;
        }, new { profileId }).ToList();

        return myKeeps;
    }

    internal List<Vault> GetUserVaults(string profileId, string userId)
    {
        string sql = @"
        SELECT
        vaults.*,
        accounts.*
        FROM vaults
        JOIN accounts ON accounts.id = vaults.creatorId
        WHERE vaults.creatorId = @profileId AND (vaults.creatorId = @userId OR vaults.isPrivate = false);";

        List<Vault> myVaults = _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => 
        {
            vault.Creator = profile;
            return vault;
        }, new { profileId, userId }).ToList();

            return myVaults;
    }
}

