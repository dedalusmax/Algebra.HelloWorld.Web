﻿using Algebra.HelloWorld.Web.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Algebra.HelloWorld.Web.MvcApp.Controllers
{
    public class AccountController : Controller
    {
        // simulacija baze podataka
        private static List<Account> _accounts;

        public AccountController()
        {
            if (_accounts == null)
            {
                _accounts = new List<Account>();

                _accounts.Add(new Account() { Id = 1, Name = "Tekući račun", DateOfIssue = DateTime.Today.AddMonths(-3), Number = 123213213 });
                _accounts.Add(new Account() { Id = 2, Name = "Žiro-račun", DateOfIssue = DateTime.Today.AddMonths(-1), Number = 23213232 });
                _accounts.Add(new Account() { Id = 3, Name = "Devizni račun", DateOfIssue = DateTime.Today.AddMonths(-2), Number = 343434343 });
            }
        }

        public IActionResult Index()
        {
            return View(_accounts);
        }

        #region Create actions

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Account model)
        {
            _accounts.Add(model);

            return RedirectToAction("Index");
        }

        #endregion

        public IActionResult Details(int id)
        {
            var account = _accounts.SingleOrDefault(x => x.Id == id);

            return View(account);
        }

        public IActionResult Delete(int id)
        {
            var account = _accounts.SingleOrDefault(x => x.Id == id);

            return View(account);
        }

        [HttpPost]
        public IActionResult Delete(Account model)
        {
            var account = _accounts.SingleOrDefault(x => x.Id == model.Id);

            _accounts.Remove(account);

            return RedirectToAction("Index");
        }
    }
}
