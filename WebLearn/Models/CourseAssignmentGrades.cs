using Microsoft.Data.SqlClient.DataClassification;
using System.ComponentModel.DataAnnotations;

namespace WebLearn.Models
{
    public class CourseAssignmentGrades
    {
        [Key]
        public int CAGId { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int CourseOnly { get; set; }
        public int AssignmentId { get; set; }
        public int GradeId { get; set; }
    }
}
