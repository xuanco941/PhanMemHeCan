using Microsoft.AspNetCore.Mvc;
using PhanMemHeCan.Models;
using System.Diagnostics;

namespace PhanMemHeCan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}