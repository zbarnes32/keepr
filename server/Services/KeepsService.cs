


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

    internal List<Keep> GetAllKeeps()
    {
        List<Keep> keeps = _repository.GetAllKeeps();
        return keeps;
    }

    internal Keep GetKeepById(int keepId)
    {
        Keep keep = _repository.GetKeepById(keepId);

        if (keep == null)
        {
            throw new Exception($"Unable to find keep with the id of {keepId}");
        }
        return keep;
    }
}
