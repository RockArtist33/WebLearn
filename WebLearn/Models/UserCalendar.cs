namespace WebLearn.Models
{
    public class UserCalendar
    {
        public int UserCalendarId { get; set; }
        public ICollection<CalendarEvents> CalendarEvents { get; } = new List<CalendarEvents>();
        public ICollection<Users> Users { get; } = new List<Users>();
    }
}
