using Microsoft.AspNetCore.Mvc;

namespace WebLibrary.Controllers
{
    public class LandingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}