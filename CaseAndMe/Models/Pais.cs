﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMe.Models
{
    public class Pais : Comun
    {
        public string CountryISO { get; set; }
        
        public virtual ICollection<Estado> Estados { get; set; }
    }
}