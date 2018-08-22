﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMe.Models
{
    public class Base<TKey>
    {
        public TKey Id { get; set; }
        public DateTime FechaMod { get; set; }
        public DateTime FechaAlt { get; set; }
        public bool EsActivo { get; set; }
    }
}
