namespace WebLearn.Models
{
    public class Attachments
    {
        public int AttachmentId { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentDescription { get; set; }
        public string AttachmentUrl { get; set; }
        public int AssignmentId { get; set; }
        public Assignments Assignments { get; set; }
    }
}
