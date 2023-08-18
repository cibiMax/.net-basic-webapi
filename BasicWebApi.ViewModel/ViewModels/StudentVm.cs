using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.ViewModel.ViewModels
{
    public class StudentVm
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
     
        public decimal Phoneno { get; set; }
        public string? Address { get; set; }

    }
}
