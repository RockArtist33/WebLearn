namespace WebLearn.Models
{
    public class Assignments
    {
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public string AssignmentDescription { get; set; }
        public ICollection<Attachments> Attachments { get; } = new List<Attachments>();
        public ICollection<Users> Users { get; } = new List<Users>();
        public ICollection<Courses> Courses { get; } = new List<Courses>();

        
    }
}
