using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Termine.Models;

namespace Termine.Controllers
{
    public class AdminController : Controller
    {
        // static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;";
        static string selectAll = "SELECT * FROM master.dbo.Schedule";
        List<ScheduleDay> scheduleDays = new List<ScheduleDay>();
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            using(SqlConnection connection = new SqlConnection(DatabaseHelper.DatabaseHelper.ConnectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(selectAll, connection);
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    scheduleDays.ToList().Clear();
                    while (await reader.ReadAsync())
                    {
                        byte dayOfWeek = reader.GetByte(0);
                        TimeSpan from = reader.GetTimeSpan(1);
                        TimeSpan to = reader.GetTimeSpan(2);
                        scheduleDays.Add(new ScheduleDay(dayOfWeek, from, to));
                    }
                }
            } 
            return View(new ScheduleDays(scheduleDays));
        }
    
        [HttpPost]
        public async void Index(ScheduleDays days)
        {
            string insertValues = String.Empty;
            foreach(var time in days.scheduleDays)
                insertValues += $"UPDATE master.dbo.Schedule SET [From]='{time.from}', [To]='{time.to}' WHERE DayOfWeek={time.dayOfWeek};";
            using (SqlConnection connection = new SqlConnection(DatabaseHelper.DatabaseHelper.ConnectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(insertValues, connection);
                await command.ExecuteNonQueryAsync();
            }   
        }
    }
}