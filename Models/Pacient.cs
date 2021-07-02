using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectFinal.Models
{
    public class Pacient
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Range(1,Double.MaxValue)]
        public int Age { get; set; }
        [Required]
        public String Disease { get; set; }
        [Range(1,999999)]
        public int ReceiptNr { get; set; }
        [Required]
        public String ReceiptDescription { get; set; }
        public List<Product> Products { get; set; }
        public Pharmacist Pharmacist { get; set; }
    }
}
