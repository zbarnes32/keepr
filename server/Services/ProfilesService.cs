


namespace keepr.Services;

public class ProfilesService
{
    private readonly ProfilesRepository _repository;
    private readonly VaultsService _vaultsService;

    public ProfilesService(ProfilesRepository repository, VaultsService vaultsService)
    {
        _repository = repository;
        _vaultsService = vaultsService;
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

    internal List<Vault> GetUserVaults(string userId, string profileId)
    {
        
        List<Vault> myVaults = _repository.GetUserVaults(profileId, userId);
        
        return myVaults;
    }
}
