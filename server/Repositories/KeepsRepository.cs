
namespace keepr.Repositories;

public class KeepsRepository
{
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Keep CreateKeep(Keep keepData)
    {
        string sql = @"
        INSERT INTO
        keeps(name, description, img, creatorId)
        VALUES(@Name, @Description, @Img, @CreatorId);

        SELECT
        keeps.*,
        accounts.*
        FROM keeps
        JOIN accounts ON accounts.id = keeps.creatorId
        WHERE keeps.id = LAST_INSERT_ID();";

        Keep keep = _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
        {
            keep.Creator = profile;
            return keep;
        }, keepData).FirstOrDefault();

        return keep;
    }

    internal void DestroyKeep(int keepId)
    {
        string sql = "DELETE FROM keeps WHERE id = @keepId LIMIT 1;";

        int rowsAffected = _db.Execute(sql, new { keepId });

        if (rowsAffected == 0) throw new Exception("Unable to delete.");
        if (rowsAffected > 1) throw new Exception("Deleted more than attended.");
    }

    internal List<Keep> GetAllKeeps()
    {

        // TODO add the SQL Count for kept

        string sql = @"
        SELECT 
        keeps.*,
        COUNT(vaultKeeps.id) AS kept,
        accounts.*
        FROM keeps
        JOIN accounts ON accounts.id = keeps.creatorId
        LEFT JOIN vaultKeeps ON vaultKeeps.keepId = keeps.id
        GROUP BY (keeps.id);";

        List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql,
        (keep, profile) =>
        {
            keep.Creator = profile;
            return keep;
        }).ToList();

        return keeps;
    }

    internal Keep GetKeepById(int keepId)
    {
        // TODO add the sql count here as well after you get it ^^^ there
        string sql = @"
        SELECT
        keeps.*,
        accounts.*
        FROM keeps
        JOIN accounts ON accounts.id = keeps.creatorId
        WHERE keeps.id = @keepId;";

        Keep keep = _db.Query<Keep, Profile, Keep>(sql,
        (keep, profile) =>
    {
        keep.Creator = profile;
        return keep;
    }, new { keepId }).FirstOrDefault();

        return keep;
    }

    internal Keep UpdateKeep(Keep keepData)
    {
        string sql = @"
        UPDATE keeps
        SET
        name = @Name,
        description = @Description,
        img = @Img,
        views = @Views
        WHERE id = @Id LIMIT 1;

        SELECT
        keeps.*,
        accounts.*
        FROM keeps
        JOIN accounts ON accounts.id = keeps.creatorId
        WHERE keeps.id = @Id;";

        Keep keep = _db.Query<Keep, Profile, Keep>(sql,
        (keep, profile) =>
    {
        keep.Creator = profile;
        return keep;
    }, keepData).FirstOrDefault();

        return keep;
    }
}

