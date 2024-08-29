


namespace keepr.Services;

public class KeepsService
{
    private readonly KeepsRepository _repository;

    public KeepsService(KeepsRepository repository)
    {
        _repository = repository;
    }

    internal Keep CreateKeep(Keep keepData)
    {
        Keep keep = _repository.CreateKeep(keepData);
        return keep;
    }

    internal string DestroyKeep(int keepId, string userId)
    {
        Keep keepToDestroy = GetKeepById(keepId, userId);
        if (keepToDestroy.CreatorId != userId)
        {
            throw new Exception("Unable to delete a keep you did not create.");
        }

        _repository.DestroyKeep(keepId);

        return $"{keepToDestroy.Name} has been deleted.";
    }

    internal List<Keep> GetAllKeeps()
    {
        List<Keep> keeps = _repository.GetAllKeeps();
        return keeps;
    }

    internal Keep GetKeepById(int keepId, string userId)
    {
        Keep keep = _repository.GetKeepById(keepId);

        if (keep == null)
        {
            throw new Exception($"Unable to find keep with the id of {keepId}");
        }
        return keep;
    }

    internal Keep IncrementViews(int keepId, string userId)
    {
        Keep keep = GetKeepById(keepId, userId);

        keep.Views++;

        _repository.UpdateKeep(keep);

        return keep;
    }

    internal Keep UpdateKeep(int keepId, string userId, Keep keepData)
    {
        Keep keepToUpdate = GetKeepById(keepId, userId);

        if(keepToUpdate.CreatorId != userId)
        {
            throw new Exception("Unable to update a keep that you did not create");
        }

        keepToUpdate.Name = keepData.Name ?? keepToUpdate.Name;
        keepToUpdate.Description = keepData.Description ?? keepToUpdate.Description;
        keepToUpdate.Img = keepData.Img ?? keepToUpdate.Img;
        
        Keep updatedKeep = _repository.UpdateKeep(keepToUpdate);
        return updatedKeep;
    }
}
