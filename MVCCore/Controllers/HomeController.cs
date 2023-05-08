using Microsoft.AspNetCore.Mvc;
using MVCCore.Models;
using System.Diagnostics;

namespace MVCCore.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {
            log lg= new log()
            {
                Username= form["username"],
                Password = form["Password"],

            };

            if(lg.Username=="user"&&lg.Password== "user")
            {
                return RedirectToAction("Index", "Login");
            }
            else if(lg.Password == "admin" && lg.Password == "admin")
            {
                return RedirectToAction("Index", "Login");
            }


            return View();
        }
    }
}