using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWEbApi.Models.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }//primary key
        [Required]
        public string? Name { get; set; }//required field
        public int Phoneno { get; set; }
        public string? Address { get; set; }

    }
}
