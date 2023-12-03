using System.ComponentModel.DataAnnotations;

namespace WebLearn.Models
{
    public class UserCalendar
    {
        [Key]
        public int UserCalendarId { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}
