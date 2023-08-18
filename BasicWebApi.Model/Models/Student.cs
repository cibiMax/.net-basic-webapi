using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Model.Models
{
    public class Student
    {

        public int Id { get; set; }
    
        public string? Name { get; set; }
        public decimal Phoneno { get; set; }
        public string? Address { get; set; }

    }
}
