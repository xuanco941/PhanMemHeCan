using Microsoft.AspNetCore.Mvc;

namespace PhanMemHeCan.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
