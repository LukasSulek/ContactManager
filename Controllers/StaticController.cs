using ECoding_MVC_app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECoding_MVC_app.Controllers
{
    public class StaticController : Controller
    {
        private readonly ILogger<StaticController> _logger;

        public StaticController(ILogger<StaticController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}