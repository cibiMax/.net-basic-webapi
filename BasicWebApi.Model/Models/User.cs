namespace basicwebapi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set;}
        public int CreatedBy { get; set; }
        public int LastUpdatedBy { get; set;}
    }
}
