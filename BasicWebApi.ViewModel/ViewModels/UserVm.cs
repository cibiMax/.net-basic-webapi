using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.ViewModel.ViewModels
{
    public class UserVm
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ? Email { get; set; }
        [Required]
        public string ? Password { get; set; }

        public string Role { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int LastUpdatedBy { get; set; }
    }
}
