using System.ComponentModel.DataAnnotations;

namespace basicwebapi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set;}
        public int CreatedBy { get; set; }
        public int LastUpdatedBy { get; set;}
    }
}
