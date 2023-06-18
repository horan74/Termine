using Microsoft.AspNetCore.Mvc;
using Termine.Models;

namespace Termine.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dayId = (byte) DateTime.Now.DayOfWeek;
            ScheduleDay result = await DatabaseHelper.DatabaseHelper.SelectDayAsync(dayId);
            ViewData["DateString"] = DateTime.Now.ToString("yyyy-MM-dd");
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
                return View(result);
            }       
            return View();
        }
    }
}