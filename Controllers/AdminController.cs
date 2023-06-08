using Microsoft.AspNetCore.Mvc;

namespace Termine.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}