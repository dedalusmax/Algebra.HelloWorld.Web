using Algebra.HelloWorld.Web.MvcApp.Interfaces;
using Algebra.HelloWorld.Web.MvcApp.Models;

namespace Algebra.HelloWorld.UnitTests;

internal class StubAccountRepository : IAccountRepository
{
    public void Create(Account account)
    {
        throw new NotImplementedException();
    }

    public void Delete(Account account)
    {
        throw new NotImplementedException();
    }

    public List<Account> GetAccounts()
    {
        throw new NotImplementedException();
    }

    public Account? GetById(int id)
    {
        throw new NotImplementedException();
    }
}
