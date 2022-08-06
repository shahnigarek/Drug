using Core.Abstarctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Pharmacy: IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }    
        public string Address { get; set; } 
        public string ContactNumber { get; set; }
        public Owner Owner { get; set; }    
        public List<Medicine> Medicines { get; set; }
        public List<Apothecary> Apothecaries { get; set; }
        public Pharmacy()
        {
            Medicines = new List<Medicine>();
            Apothecaries = new List<Apothecary>();

        }
    }
}
