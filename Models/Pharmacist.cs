using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectFinal.Models
{
    public class Pharmacist
    {
        public int Id { get; set; }
        [MinLength(3)]
        public String Name { get; set; }
        [Required]
        public String Role { get; set; }

    }
}
