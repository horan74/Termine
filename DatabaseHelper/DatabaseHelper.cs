using Microsoft.Data.SqlClient;
using Termine.Models;

namespace Termine.DatabaseHelper
{
    public class DatabaseHelper
    {
        public static string ConnectionString 
        {
            get { return "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;"; }
        }

        public static async Task<ScheduleDay> SelectDayAsync(byte dayId)
        {
            ScheduleDay? result = null;
            using(var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                string query = $"SELECT * FROM master.dbo.Schedule WHERE DayOfWeek={dayId}";
                SqlCommand command = new SqlCommand(query, connection);
                using (var reader =  await command.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
                    {
                        byte dayOfWeek = reader.GetByte(0);
                        TimeSpan from = reader.GetTimeSpan(1);
                        TimeSpan to = reader.GetTimeSpan(2);
                        result = new ScheduleDay(dayOfWeek, from, to);
                    }
                }
            }
            return result;
        }
    }
}