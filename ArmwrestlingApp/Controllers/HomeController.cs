using System.Diagnostics;
using ArmwrestlingApp.Models;
using ArmwrestlingApp.ViewModels.Competition;
using Microsoft.AspNetCore.Mvc;

namespace ArmwrestlingApp.Controllers
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
            // Simulate some data for the example
            var competitions = new List<CompetitionViewModel>
        {
            new CompetitionViewModel { Id = 1, Name = "Tournament 1", Date = new DateTime(2025, 5, 10), Location = "New York" },
            new CompetitionViewModel { Id = 2, Name = "Tournament 2", Date = new DateTime(2025, 6, 15), Location = "Los Angeles" },
            new CompetitionViewModel { Id = 3, Name = "Tournament 3", Date = DateTime.Today, Location = "Chicago" },
            new CompetitionViewModel { Id = 4,Name = "Tournament 4", Date = new DateTime(2023, 9, 10), Location = "Miami" }
        };

            var viewModel = new CompetitionListViewModel
            {
                PastCompetitions = competitions.Where(c => c.Date < DateTime.Today).ToList(),
                FutureCompetitions = competitions.Where(c => c.Date >= DateTime.Today).ToList()
            };


            if (viewModel.PastCompetitions.Any()) 
            {

            }
            return View(viewModel);
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
