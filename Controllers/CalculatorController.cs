using CalculatorMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace CalculatorMVC.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
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

        public string Calculate(string input)
        {
            DataTable dt = new DataTable();
            string result;
            try
            {
                result = "" + dt.Compute(input, "");

            }
            catch (SyntaxErrorException)
            {
                result = "" + dt.Compute(input + input.Substring(0, input.Length - 3), "");
            }
            return result;
        }
    }
}