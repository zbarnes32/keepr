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

[HttpGet]
public ActionResult<List<Keep>> GetAllKeeps()
{
    try 
    {
    List<Keep> keeps = _keepsService.GetAllKeeps();
    return Ok(keeps);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
}

[HttpGet("{keepId}")]
public ActionResult<Keep> GetKeepById(int keepId)
{
    try 
    {
        Keep keep = _keepsService.GetKeepById(keepId);
        return Ok(keep);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
}

[HttpPut("{keepId}")]
[Authorize]
public async Task<ActionResult<Keep>> UpdateKeep(int keepId, [FromBody] Keep keepData)
{
    try 
    {
        Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
        Keep keep = _keepsService.UpdateKeep(keepId, userInfo.Id, keepData);
        return Ok(keep);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
}

[HttpDelete("{keepId}")]
[Authorize]
public async Task<ActionResult<string>> DestroyKeep(int keepId)
{
    try 
    {
        Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
        string message = _keepsService.DestroyKeep(keepId, userInfo.Id);
        return Ok(message);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
}

}
