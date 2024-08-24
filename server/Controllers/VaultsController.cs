namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]

public class VaultsController
{
    private readonly VaultsService _vaultsService;
    private readonly Auth0Provider _auth0Provider;

    public VaultsController(VaultsService vaultsService, Auth0Provider auth0Provider)
    {
        _vaultsService = vaultsService;
        _auth0Provider = auth0Provider;
    }
}
