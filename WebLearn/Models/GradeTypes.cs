namespace WebLearn.Models
{
    public class GradeTypes
    {
        public int GradeTypesId { get; set; }
        public string GradeTypesName { get;set; }
        public int GradeId { get; set; }
        public Grades Grades { get; set; }
    }
}
