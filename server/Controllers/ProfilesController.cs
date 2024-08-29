namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProfilesController : ControllerBase
{
    private readonly ProfilesService _profilesService;
    private readonly Auth0Provider _auth0Provider;
    private readonly VaultsService _vaultsService;

    public ProfilesController(ProfilesService profilesService, Auth0Provider auth0Provider, VaultsService vaultsService)
    {
        _profilesService = profilesService;
        _auth0Provider = auth0Provider;
        _vaultsService = vaultsService;

    }

    [HttpGet("{profileId}")]
    public ActionResult<Profile> GetProfileById(string profileId)
    {
        try 
        {
            Profile profile = _profilesService.GetProfileById(profileId);
            return Ok(profile);
        }
        catch (Exception exception)
        {
          return BadRequest(exception.Message);
        }
    }

    [HttpGet("{profileId}/keeps")]

    public async Task<ActionResult<List<Keep>>> GetUserKeeps(string profileId)
    {
        try 
        {
            
            List<Keep> myKeeps = _profilesService.GetUserKeeps(profileId);
            return Ok(myKeeps);
        }
        catch (Exception exception)
        {
          return BadRequest(exception.Message);
        }
    }

    [HttpGet("{profileId}/vaults")]
    async public Task<ActionResult<List<Vault>>> GetUserVaults(string profileId)
    {
        try 
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            // Vault vault = _vaultsService.GetVaultById(vaultId, userInfo?.Id);
            List<Vault> myVaults = _profilesService.GetUserVaults(userInfo?.Id, profileId);
            return Ok(myVaults);
        }
        catch (Exception exception)
        {
          return BadRequest(exception.Message);
        }
    }
}
