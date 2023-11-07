namespace WebLearn.Models
{
    public class Users
    {
        public int user_id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? Timezone { get; set; }
        public string concurrency_stamp { get; set; }
    }
}
