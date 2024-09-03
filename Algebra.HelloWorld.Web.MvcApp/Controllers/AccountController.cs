using Microsoft.AspNetCore.Mvc;

namespace Algebra.HelloWorld.Web.MvcApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
