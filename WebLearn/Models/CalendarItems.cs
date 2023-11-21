namespace WebLearn.Models
{
    public class CalendarItems
    {
        public int CalendarItemsId { get; set; }
        public ICollection<CalendarEvents> CalendarEvents { get; } = new List<CalendarEvents>();
    }
}
