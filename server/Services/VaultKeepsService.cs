


namespace keepr.Services;

public class VaultKeepsService
{
    private readonly VaultKeepsRepository _repository;
    public VaultKeepsService(VaultKeepsRepository repository)
    {
        _repository = repository;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
    {
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

    internal List<VaultKeepKeep> GetKeepsInAPublicVault(int vaultId)
    {
        List<VaultKeepKeep> keeps = _repository.GetKeepsInAPublicVault(vaultId);
        return keeps;
    }
    }

