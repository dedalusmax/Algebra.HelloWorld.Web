namespace Algebra.HelloWorld.Web.MvcApp.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Total { get; set; }

        public List<Transaction> Transactions { get; set; } = [];
    }

    public class Transaction
    {
        public Guid Id { get; set; }

        public decimal Amount { get; set; }
    }
}
