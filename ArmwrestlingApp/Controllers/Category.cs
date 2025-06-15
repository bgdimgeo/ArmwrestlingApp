using Microsoft.AspNetCore.Mvc;

namespace ArmwrestlingApp.Controllers
{
    public class Category : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
