using Microsoft.AspNetCore.Mvc;

namespace P3.Controllers
{
    // The SplashController is responsible for handling requests related to the splash page
    public class SplashController : Controller
    {
        public IActionResult Index()
        {
            // Return the view named "Index" using the layout named "_SplashLayout"
            // The "Index" view represents the splash page
            // The "_SplashLayout" is a custom layout file specifically designed for the splash page
            return View("Index", "_SplashLayout");
        }
    }
}