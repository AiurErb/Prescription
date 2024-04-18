using Microsoft.AspNetCore.Mvc;
using Prescriptions.MVC.Models;
using System.Diagnostics;

namespace Prescriptions.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string? _connectionString;

        public HomeController(ILogger<HomeController> logger, IConfiguration appConfig)
        {
            _logger = logger;
            _connectionString = appConfig.GetConnectionString("SqlServerLocal");
        }

        public IActionResult Index()
        {
            Console.WriteLine(_connectionString);
            _logger.LogInformation("test");
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
    }
}
