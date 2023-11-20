using System.ComponentModel.DataAnnotations;

namespace WebLearn.Models
{
    public class Grades
    {
        [Key]
        public int GradeId { get; set; }
        public int GradeTypeId { get; set; }
        public string? Rank { get; set; }
    }
}
