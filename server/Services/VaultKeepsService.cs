


using Microsoft.Extensions.Configuration.UserSecrets;

namespace keepr.Services;

public class VaultKeepsService
{
    private readonly VaultKeepsRepository _repository;
    private readonly VaultsService _vaultsService;
    public VaultKeepsService(VaultKeepsRepository repository, VaultsService vaultsService)
    {
        _repository = repository;
        _vaultsService = vaultsService;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData, string userId)
    {
        Vault vault = _vaultsService.GetVaultById(vaultKeepData.VaultId, userId);
       
        if( userId != vault.CreatorId)
        {
            throw new Exception("Unable to create a vaultkeep.");
        }
        
       VaultKeep vaultKeep = _repository.CreateVaultKeep(vaultKeepData);

       return vaultKeep; 
    }

    internal string DestroyVaultKeep(int vaultKeepId, string userId)
    {
        VaultKeep vaultKeep = GetVaultKeepById(vaultKeepId);

        if (vaultKeep.CreatorId != userId)
        {
        throw new Exception("You can't delete something you don't own.");
        }

        _repository.DestroyVaultKeep(vaultKeepId);

        return "VaultKeep has been delete";
    }

    private VaultKeep GetVaultKeepById(int vaultKeepId)
    {
        VaultKeep vaultKeep = _repository.GetVaultKeepById(vaultKeepId);

        if (vaultKeep == null)
        {
            throw new Exception($"Unable to find a vaultKeepId of {vaultKeepId}");
        }

        return vaultKeep;
    }

    internal List<VaultKeepKeep> GetKeepsInAPublicVault(string userId, int vaultId)
    {
        Vault vault = _vaultsService.GetVaultById(vaultId, userId);
        List<VaultKeepKeep> keeps = _repository.GetKeepsInAPublicVault(vaultId);

        if(userId != vault.CreatorId && vault.IsPrivate == true)
        {
            throw new Exception ($"Unable to find vault with id of {vault.Id}");
        }

        return keeps;
    }
    }

