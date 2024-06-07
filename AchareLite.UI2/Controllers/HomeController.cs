using Microsoft.AspNetCore.Mvc;

namespace AchareLite.UI2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
