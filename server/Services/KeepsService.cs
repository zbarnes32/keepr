

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
}
