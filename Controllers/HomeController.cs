using Microsoft.AspNetCore.Mvc;

namespace Termine.AddControllersWithViews
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index() 
        {
            try {
                var json = await Request.ReadFromJsonAsync<Date>();
                if (json != null)
                Console.WriteLine($"{json.date}");
            }
            catch {}
            return View();
        }
    }

    public record Date(String date);
}