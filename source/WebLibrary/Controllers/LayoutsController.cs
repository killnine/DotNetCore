using Microsoft.AspNetCore.Mvc;

namespace WebLibrary.Controllers
{
    public class LayoutsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OffCanvas()
        {
            return View();
        }
    }
}