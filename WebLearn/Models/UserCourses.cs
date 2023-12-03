using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebLearn.Models
{
    public class UserCourses
    {
        [Key]
        public int UserCoursesId { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }

    }
}
