﻿using System.ComponentModel;

namespace Algebra.HelloWorld.Web.MvcApp.Models;

public class Account
{
    public int Id { get; set; }

    [DisplayName("IBAN računa")]
    public long Number { get; set; }

    [DisplayName("Datum otvaranja računa")]
    public DateTime DateOfIssue { get; set; } = DateTime.Today;

    [DisplayName("Naziv računa")]
    public string Name { get; set; } = string.Empty;

    [DisplayName("Saldo računa")]
    public decimal Total { 
        get {
            decimal total = 0;
            foreach (var transaction in Transactions)
            {
                total += transaction.Amount;
            }

            return total;
        }
    }

    [DisplayName("Lista transakcija")]
    public List<AccountTransaction> Transactions { get; set; } = [];

    //[DisplayName("Saldo računa")]
    //public decimal CalculateTotal()
    //{
    //    decimal total = 0;
    //    foreach(var transaction in Transactions)
    //    {
    //        total += transaction.Amount;
    //    }

    //    return total;
    //}
}
