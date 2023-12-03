using System.ComponentModel.DataAnnotations;

namespace WebLearn.Models
{
    public class GradeTypes
    {
        [Key]
        public int GradeTypeId { get; set; }
        public string GradeTypesName { get;set; }
    }
}
