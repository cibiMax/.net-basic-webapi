using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Model.Models
{
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Token { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required]
        public int RefreshCount { get; set; }

        [Required]

        public DateTime ExpirationTime { get; set; }

        public bool IsActive { get; set; }

    }
}
    