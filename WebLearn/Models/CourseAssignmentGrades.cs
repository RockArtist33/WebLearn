namespace WebLearn.Models
{
    public class CourseAssignmentGrades
    {
        public int CAGId { get; set; }
        public ICollection<Users> Users { get; } = new List<Users>();
        public ICollection<Courses> Courses { get; } = new List<Courses>();
        public int CourseOnly { get; set; }
        public ICollection<Assignments> Assignments { get; } = new List<Assignments>();
        public ICollection<Grades> Grades { get; } = new List<Grades>();
    }
}
