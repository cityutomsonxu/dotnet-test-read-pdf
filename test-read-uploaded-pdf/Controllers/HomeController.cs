using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using test_read_uploaded_pdf.Models;

namespace test_read_uploaded_pdf.Controllers
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

        public IActionResult itextcore()
        {
            return View();
        }

        public IActionResult itextsharp()
        {
            return View();
        }

        public IActionResult pdfsharp()
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
    }
}