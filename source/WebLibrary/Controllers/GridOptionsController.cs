using Microsoft.AspNetCore.Mvc;

namespace WebLibrary.Controllers
{
    public class GridOptionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}