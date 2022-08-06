using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class MedicineRepository : IRepository<Medicine>
    {
        private static int id;
        public Medicine Create(Medicine entity)
        {
            id++;
            entity.ID = id;
            try
            {
                Dbcontexts.Medicines.Add(entity);

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
            return entity;
        }

        public void Delete(Medicine entity)
        {
            try
            {

                Dbcontexts.Medicines.Remove(entity);
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
        }

        public Medicine Get(Predicate<Medicine> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return Dbcontexts.Medicines[0];
                }
                else
                {
                    return Dbcontexts.Medicines.Find(filter);
                }

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public List<Medicine> GetAll(Predicate<Medicine> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return Dbcontexts.Medicines;

                }
                else
                {
                    return Dbcontexts.Medicines.FindAll(filter);
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public void Update(Medicine entity)
        {
            try
            {
                var medicine = Dbcontexts.Medicines.Find(a => a.ID == entity.ID);
                if (medicine != null)
                {

                    medicine.ID = entity.ID;
                    medicine.Name = entity.Name;
                    medicine.Price = entity.Price;
                    medicine.Pharmacy = entity.Pharmacy;
                    medicine.Count=entity.Count;    
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
        }
    }
}
