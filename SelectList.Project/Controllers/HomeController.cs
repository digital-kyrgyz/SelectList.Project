using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SelectList.Project.Models;
using SelectList.Project.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SelectList.Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var jsonList = _configuration.GetSection("Needs:People").Get<List<PeopleVm>>().ToList();
            ViewData["People"] = jsonList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(PeopleVm peole)
        {
            if (ModelState.IsValid)
            {
                if (true)
                {
                    System.Console.WriteLine("Ok");
                    return RedirectToAction(nameof(HomeController.Privacy), "Home");
                }
            }
            return View(peole);
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