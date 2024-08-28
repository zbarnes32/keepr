using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]

public class VaultsController : ControllerBase
{
    private readonly VaultsService _vaultsService;
    private readonly Auth0Provider _auth0Provider;
    private readonly VaultKeepsService _vaultKeepsService;

    public VaultsController(VaultsService vaultsService, Auth0Provider auth0Provider, VaultKeepsService vaultKeepsService)
    {
        _vaultsService = vaultsService;
        _auth0Provider = auth0Provider;
        _vaultKeepsService = vaultKeepsService;
    }

    [HttpPost]
    [Authorize]

    public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault vaultData)
    {
        try 
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            vaultData.CreatorId = userInfo.Id;
            Vault vault = _vaultsService.CreateVault(vaultData);
            return Ok(vault);
        }
        catch (Exception exception)
        {
          return BadRequest(exception.Message);
        }
    }

    [HttpGet("{vaultId}")]
    async public Task<ActionResult<Vault>> GetVaultById(int vaultId)
    {
        try 
        {
        Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
        Vault vault = _vaultsService.GetVaultById(vaultId, userInfo?.Id);
        return Ok(vault);
        }
        catch (Exception exception)
        {
          return BadRequest(exception.Message);
        }
    }

    [HttpPut("{vaultId}")]
    [Authorize]
    public async Task<ActionResult<Vault>> UpdateVault(int vaultId, [FromBody] Vault vaultData)
    {
        try 
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            Vault vault = _vaultsService.UpdateVault(vaultId, userInfo.Id, vaultData);
            return Ok(vault);
        }
        catch (Exception exception)
        {
          return BadRequest(exception.Message);
        }
    }

    [HttpDelete("{vaultId}")]
    [Authorize]
    public async Task<ActionResult<string>> DestroyVault(int vaultId)
    {
        try 
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string message = _vaultsService.DestroyVault(vaultId, userInfo.Id);
            return Ok(message);
        }
        catch (Exception exception)
        {
          return BadRequest(exception.Message);
        }
    }

    [HttpGet("{vaultId}/keeps")]
    public async Task<ActionResult<List<VaultKeepKeep>>> GetKeepsInAPublicVault(int vaultId)
    {
        try 
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            List<VaultKeepKeep> keeps = _vaultKeepsService.GetKeepsInAPublicVault(userInfo?.Id, vaultId);
            return Ok(keeps);
        }
        catch (Exception exception)
        {
          return BadRequest(exception.Message);
        }
    }

}
