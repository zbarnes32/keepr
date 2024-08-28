


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

    internal string DestroyVault(int vaultId, string userId)
    {
       Vault vaultToDestroy = GetVaultById(vaultId);
       if (vaultToDestroy.CreatorId != userId)
       {
        throw new Exception("Unable to delete a vault that is not yours.");
       }

       _repository.DestroyVault(vaultId);

       return $"The {vaultToDestroy.Name} has been deleted.";
    }

    internal Vault GetVaultById(int vaultId)
    {
        Vault vault = _repository.GetVaultById(vaultId);

        if(vault == null || vault.IsPrivate == true)
        {
            throw new Exception($"Unable to find a vault with the id of {vaultId}");
        }

        return vault;
    }

    internal Vault UpdateVault(int vaultId, string userId, Vault vaultData)
    {
        Vault vaultToUpdate = GetVaultById(vaultId);

        if (vaultToUpdate.CreatorId != userId)
        {
            throw new Exception("Unable to make changes to a vault you did not create.");
        }

        vaultToUpdate.Name = vaultData.Name ?? vaultToUpdate.Name;
        vaultToUpdate.Description = vaultData.Description ?? vaultToUpdate.Description;
        vaultToUpdate.Img = vaultData.Img ?? vaultToUpdate.Img;
        vaultToUpdate.IsPrivate = vaultData.IsPrivate ?? vaultToUpdate.IsPrivate;

        Vault updatedVault = _repository.UpdateVault(vaultToUpdate);
        return updatedVault;
    }
}
