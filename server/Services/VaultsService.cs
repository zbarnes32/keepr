

namespace keepr.Services;

public class VaultsService
{
    private readonly VaultsRepository _repository;

    public VaultsService(VaultsRepository repository)
    {
        _repository = repository;
    }

    internal Vault CreateVault(Vault vaultData)
    {
        Vault vault = _repository.CreateVault(vaultData);
        return vault;
    }

    internal Vault GetVaultById(int vaultId)
    {
        Vault vault = _repository.GetVaultById(vaultId);

        if(vault == null)
        {
            throw new Exception($"Unable to find a vault with the id of {vaultId}");
        }

        return vault;
    }
}
