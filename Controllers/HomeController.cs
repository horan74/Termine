using Microsoft.AspNetCore.Mvc;

namespace Termine.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index() 
        {
            try {
                var json = await Request.ReadFromJsonAsync<Date>();
                if (json != null)
                {
                    DateOnly dateOnly = DateOnly.Parse(json.date);
                    Console.WriteLine($"{(int)DayOfWeek.Sunday}");
                }
            }
            catch {}
            return View();
        }
    }

    public record Date(String date);
}