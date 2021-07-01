using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectFinal.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(10,10000)]
        public int Price { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public Boolean WithRp { get; set; }

        
    }
}
