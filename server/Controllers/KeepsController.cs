using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]

public class KeepsController : ControllerBase
{
    private readonly KeepsService _keepsService;
    private readonly Auth0Provider _auth0Provider;

    public KeepsController(KeepsService keepsService, Auth0Provider auth0Provider)
    {
        _keepsService = keepsService;
        _auth0Provider = auth0Provider;
    }

[HttpPost]
[Authorize]

public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep keepData)
{
    try 
    {
        Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
        keepData.CreatorId = userInfo.Id;
        Keep keep = _keepsService.CreateKeep(keepData);
        return Ok(keep);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
}
}
