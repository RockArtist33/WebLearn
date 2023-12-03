using System.ComponentModel.DataAnnotations;

namespace WebLearn.Models
{
    public class Assignments
    {
        [Key]
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public string AssignmentDescription { get; set; }
        public int AttachmentId { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }

        
    }
}
