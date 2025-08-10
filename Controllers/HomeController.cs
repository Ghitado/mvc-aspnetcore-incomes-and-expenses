using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc_aspnetcore_incomes_and_expenses.Models;
using System.Diagnostics;

namespace mvc_aspnetcore_incomes_and_expenses.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(
            ILogger<HomeController> logger, 
            SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Transaction");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
