using Microsoft.AspNetCore.Mvc;

namespace Algebra.HelloWorld.Web.MvcApp.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
