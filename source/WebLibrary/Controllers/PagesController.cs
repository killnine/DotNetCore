using Microsoft.AspNetCore.Mvc;

namespace WebLibrary.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult SearchResults()
        {
            return View();
        }

        public IActionResult LockScreen()
        {
            return View();
        }

        public IActionResult Invoice()
        {
            return View();
        }

        public IActionResult InvoicePrint()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Login_2()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult NotFoundError()
        {
            return View();
        }

        public IActionResult InternalServerError()
        {
            return View();
        }

        public IActionResult EmptyPage()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}