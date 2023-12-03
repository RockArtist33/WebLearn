using System.ComponentModel.DataAnnotations;

namespace WebLearn.Models
{
    public class Courses
    {
        [Key]
        public int course_Id { get; set; }
        public string course_name { get; set; }
        public string course_description { get; set;}
        public string? front_image { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime created_at { get; set;}
    }
}
