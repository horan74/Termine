namespace Termine.Models
{
    public record class ScheduleDay(byte dayOfWeek, TimeSpan from, TimeSpan to);
}