using System.ComponentModel.DataAnnotations;

namespace WebLearn.Models
{
    public class Courses
    {
        public int course_Id { get; set; }
        public string course_name { get; set; }
        public string course_description { get; set;}
        [DataType(DataType.DateTime)]
        public DateTime created_at { get; set;}
        public int UserCoursesId { get; set; }
        public UserCourses UserCourses { get; set; }
        public int AssignmentId { get; set; }
        public Assignments Assignments { get; set; }
    }
}
