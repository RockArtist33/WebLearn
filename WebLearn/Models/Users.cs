using System.ComponentModel.DataAnnotations;

namespace WebLearn.Models
{
    public class Users
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        public string Timezone { get; set; }
        public int UserRolesId { get; set; }
        public UserRoles UserRoles { get; set; }
        public int UserCoursesId { get; set; }
        public UserCourses UserCourses { get; set; }
        public int UserCalendarId { get; set; }
        public UserCalendar UserCalendar { get; set;}
        public int AssignmentId { get; set; }
        public Assignments Assignments { get; set; }
        


    }
}
