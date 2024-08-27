

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

    internal List<VaultKeepKeep> GetKeepsInAPublicVault(int vaultId)
    {
        List<VaultKeepKeep> keeps = _repository.GetKeepsInAPublicVault(vaultId);
        return keeps;
    }
}
