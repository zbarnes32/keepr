namespace keepr.Services;

public class ProfileService
{
    private readonly ProfileRepository _repository;

    public ProfileService(ProfileRepository repository)
    {
        _repository = repository;
    }
}
