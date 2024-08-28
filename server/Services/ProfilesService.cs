


namespace keepr.Services;

public class ProfilesService
{
    private readonly ProfilesRepository _repository;

    public ProfilesService(ProfilesRepository repository)
    {
        _repository = repository;
    }

    internal Profile GetProfileById(string profileId)
    {
        Profile profile = _repository.GetProfileById(profileId);
        return profile;
    }

    internal List<Keep> GetUserKeeps(string profileId)
    {
        List<Keep> myKeeps = _repository.GetUserKeeps(profileId);
        return myKeeps;
    }

    internal List<Vault> GetUserVaults(string profileId)
    {
        List<Vault> myVaults = _repository.GetUserVaults(profileId);
        return myVaults;
    }
}
