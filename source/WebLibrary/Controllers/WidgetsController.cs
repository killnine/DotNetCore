using Microsoft.AspNetCore.Mvc;

namespace WebLibrary.Controllers
{
    public class WidgetsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}