using System.ComponentModel;

namespace Algebra.HelloWorld.Web.MvcApp.Models;

public class AccountTransaction
{
    public int Id { get; set; }

    [DisplayName("Iznos")]
    public decimal Amount { get; set; }

    [DisplayName("Datum izvršenja")]
    public DateTime DateOfEffect { get; set; }

    [DisplayName("Napomena")]
    public string? Note { get; set; }
}
