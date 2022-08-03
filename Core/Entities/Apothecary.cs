﻿using Core.Abstarctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Apothecary:IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }   
        public byte Experience { get; set; }
        public Pharmacy Pharmacy { get; set; }

    }
}
