
namespace keepr.Services;
public class AccountService
{
  private readonly AccountsRepository _repo;

  public AccountService(AccountsRepository repo)
  {
    _repo = repo;
  }

  private Account GetAccount(string accountId)
  {
    Account account = _repo.GetById(accountId);
    if (account == null)
    {
      throw new Exception("Invalid Account Id");
    }
    return account;
  }

  internal Account GetOrCreateAccount(Account userInfo)
  {
    Account account = _repo.GetById(userInfo.Id);
    if (account == null)
    {
      return _repo.Create(userInfo);
    }
    return account;
  }

  internal Account Edit(Profile editData, string accountId)
  {
    Account original = GetAccount(accountId);
    original.Name = editData.Name ?? original.Name;
    original.Picture = editData.Picture ?? original.Picture;
    // TODO add the cover image
    original.CoverImg = editData.CoverImg ?? original.CoverImg;

    return _repo.Edit(original);
  }

  internal List<Vault> GetMyVaults(string accountId)
  {
    List<Vault> myVaults = _repo.GetMyVaults(accountId);
    return myVaults;
  }
}
