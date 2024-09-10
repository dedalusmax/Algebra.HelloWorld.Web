using Algebra.HelloWorld.Web.MvcApp.Models;

namespace Algebra.HelloWorld.Web.MvcApp.Repositories
{
    public class AccountRepository
    {        
        // simulacija baze podataka
        private static List<Account> _accounts;

        public AccountRepository()
        {
            if (_accounts == null)
            {
                _accounts =
                [
                    new() { Id = 1, Name = "Tekući račun", DateOfIssue = DateTime.Today.AddMonths(-3), Number = 123213213 },
                    new() { Id = 2, Name = "Žiro-račun", DateOfIssue = DateTime.Today.AddMonths(-1), Number = 23213232 },
                    new() { Id = 3, Name = "Devizni račun", DateOfIssue = DateTime.Today.AddMonths(-2), Number = 343434343 }
                ];
            }
        }

        public List<Account> GetAccounts()
        {
            return _accounts;
        }

        public Account? GetById(int id) 
        { 
            return _accounts.SingleOrDefault(x => x.Id == id);
        }
            
        public void Create(Account account)
        {
            _accounts.Add(account);
        }
        
        public void Delete(Account account)
        {
            var data = _accounts.SingleOrDefault(x => x.Id == account.Id);
            if (data != null)
            {
                _accounts.Remove(data);
            }
        }
    }
}
