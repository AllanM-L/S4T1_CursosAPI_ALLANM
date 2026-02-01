using Microsoft.AspNetCore.Mvc;

namespace CursosAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
