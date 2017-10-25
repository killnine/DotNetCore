using Microsoft.AspNetCore.Mvc;

namespace WebLibrary.Controllers
{
    public class MetricsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}