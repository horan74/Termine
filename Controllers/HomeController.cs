using Microsoft.AspNetCore.Mvc;
using Termine.Models;

namespace Termine.Controllers
{
    [Route("{controller=Home}/{action=Index}")]
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dayId = (byte) DateTime.Now.DayOfWeek;
            ScheduleDay result = await DatabaseHelper.DatabaseHelper.SelectDayAsync(dayId);
            ViewData["DateString"] = DateTime.Now.ToString("yyyy-MM-dd");
            ViewData["Interval"] = await DatabaseHelper.DatabaseHelper.SelectSettingsPropertyAsync("Interval");
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string date) 
        {
            if (date != null)
            {
                DateTime dateTime;
                DateTime.TryParse(date, out dateTime);
                ScheduleDay result = await DatabaseHelper.DatabaseHelper.SelectDayAsync((byte)dateTime.DayOfWeek);
                ViewData["DateString"] = date;
                ViewData["Interval"] = await DatabaseHelper.DatabaseHelper.SelectSettingsPropertyAsync("Interval");
                return View(result);
            }       
            return View();
        }
    }
}