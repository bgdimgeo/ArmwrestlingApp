using System.Buffers.Text;
using Microsoft.AspNetCore.Mvc;

namespace ArmwrestlingApp.Controllers
{
    public class Competition : BaseController
    {
        public IActionResult Details()
        {
            return View();
        }
    }
}
