using Microsoft.AspNetCore.Mvc;

namespace ArmwrestlingApp.Controllers
{
    public class Competitor : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
