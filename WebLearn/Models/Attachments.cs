using System.ComponentModel.DataAnnotations;

namespace WebLearn.Models
{
    public class Attachments
    {
        [Key]
        public int AttachmentId { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentDescription { get; set; }
        public string AttachmentUrl { get; set; }
    }
}
