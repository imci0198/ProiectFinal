﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectFinal.Models
{
    public class Pacient
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public String Disease { get; set; }
        public int ReceiptNr { get; set; }
        public String ReceiptDescription { get; set; }

    }
}
