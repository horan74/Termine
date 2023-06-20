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
            using(var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                string query = $"SELECT * FROM master.dbo.Schedule WHERE DayOfWeek={dayId}";
                SqlCommand command = new SqlCommand(query, connection);
                using (var reader =  await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                    byte dayOfWeek = reader.GetByte(0);
                    TimeSpan from = reader.GetTimeSpan(1);
                    TimeSpan to = reader.GetTimeSpan(2);
                    return new ScheduleDay(dayOfWeek, from, to);                    
                }
            }
        }

        public static async Task<int> SelectSettingsPropertyAsync(string columnName)
        {
            using(var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                string query = $"SELECT [{columnName}] FROM master.dbo.Settings";
                var command = new SqlCommand(query, connection);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                    return reader.GetByte(0);
                }
            }
        }

        public static async Task UpdateSettingsPropertyAsync(string columnName, string value)
        {
            using(var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                string query = $"UPDATE master.dbo.Settings SET [{columnName}]={value}";
                var command = new SqlCommand(query, connection);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}