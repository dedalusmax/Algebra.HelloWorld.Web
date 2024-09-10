using Algebra.HelloWorld.Web.MvcApp.Models;

namespace Algebra.HelloWorld.Web.MvcApp.Interfaces;

public interface IAccountRepository
{
    List<Account> GetAccounts();

    Account? GetById(int id);

    void Create(Account account);

    void Delete(Account account);
}
