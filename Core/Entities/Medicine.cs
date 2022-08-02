﻿using Core.Abstarctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public  class Medicine: IEntity
    {
        public int   ID { get; set; }
        public string Name { get; set; }
        public double Price{ get; set; }
        public int Count { get; set; }  
        public Pharmacy Pharmacy   { get; set; }    

    }
}
