using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectFinal.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }     
        public string Name { get; set; }      
        public int Price { get; set; }    
        public String Description { get; set; }
        public Boolean WithRp { get; set; }

    }
}
