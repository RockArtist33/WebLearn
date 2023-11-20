using System.ComponentModel.DataAnnotations;

namespace WebLearn.Models
{
    public class Users
    {
        [Required]
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        public string Timezone { get; set; }
        


    }
}
