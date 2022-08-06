using Core.Abstarctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Owner: IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Pharmacy> Pharmacies { get; set; }
        public Owner()
        {
            Pharmacies = new List<Pharmacy>();

        }
    }
}
