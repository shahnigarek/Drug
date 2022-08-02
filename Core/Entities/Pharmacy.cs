using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Pharmacy
    {
        public int ID { get; set; }
        public string Name { get; set; }    
        public string Address { get; set; } 
        public int ContactNumber { get; set; }
        public Owner Owner { get; set; }    
        public List<Medicine> Medicines { get; set; }
        public List<Apothecary> Apothecarys { get; set; }
    }
}
