namespace WebLearn.Models
{
    public class Grades
    {
        public int GradeId { get; set; }
        public ICollection<GradeTypes> Grade_Types { get;} = new List<GradeTypes>();
        public string? Rank { get; set; }
    }
}
