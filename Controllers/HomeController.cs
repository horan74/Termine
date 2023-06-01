using Microsoft.AspNetCore.Mvc;

namespace Termine.AddControllersWithViews
{
    public class HomeController : Controller
    {
        public IActionResult Index() 
        {
            return View();
        }
    }
}