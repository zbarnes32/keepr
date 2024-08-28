namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProfileController : ControllerBase
{
    private readonly ProfileService _profileService;

    public ProfileController(ProfileService profileService)
    {
        _profileService = profileService;
    }
}
