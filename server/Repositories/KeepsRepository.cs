

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

    internal List<Keep> GetAllKeeps()
    {
        string sql = @"
        SELECT 
        keeps.*,
        accounts.*
        FROM keeps
        JOIN accounts ON accounts.id = keeps.creatorId;";

    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, 
    (keep, profile) => 
    {
        keep.Creator = profile;
        return keep;
    }).ToList();

    return keeps;
    }

 
}

