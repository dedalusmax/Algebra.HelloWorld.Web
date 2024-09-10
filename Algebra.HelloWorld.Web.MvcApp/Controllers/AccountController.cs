using Algebra.HelloWorld.Web.MvcApp.Interfaces;
using Algebra.HelloWorld.Web.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Algebra.HelloWorld.Web.MvcApp.Controllers
{
    public class AccountController : Controller
    {        
        private readonly IAccountRepository _repository;

        public AccountController(IAccountRepository repository)
        {
            _repository = repository;
            //var repository = new AccountRepository();
        }

        public IActionResult Index()
        {
            return View(_repository.GetAccounts());
        }

        #region Create actions

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Account model)
        {
            _repository.Create(model);
            return RedirectToAction("Index");
        }

        #endregion

        public IActionResult Details(int id)
        {
            return View(_repository.GetById(id));
        }

        public IActionResult Delete(int id)
        {
            return View(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Delete(Account model)
        {
            _repository.Delete(model);

            return RedirectToAction("Index");
        }
    }
}
