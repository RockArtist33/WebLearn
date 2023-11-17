using System.ComponentModel.DataAnnotations;

namespace WebLearn.Models
{
    public class CalendarEvents
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EventDate { get; set; }
        public int CalendarItemsId { get; set; }
        public CalendarItems CalendarItems { get; set; } = null!;
    }
}
