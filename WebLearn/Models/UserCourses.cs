using Microsoft.AspNetCore.Identity;

namespace WebLearn.Models
{
    public class UserCourses
    {
        public int UserCoursesId { get; set; }
        public ICollection<Users> Users { get; } = new List<Users>();
        public ICollection<Courses> Courses { get; } = new List<Courses>();
    }
}
