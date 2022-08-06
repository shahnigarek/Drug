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
    public class PharmacyRepository : IRepository<Pharmacy>
    {
        private static int id;
        public Pharmacy Create(Pharmacy entity)
        {
            id++;
            entity.ID = id;
            try
            {
                Dbcontexts.Pharmacies.Add(entity);

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
            return entity;
        }

        public void Delete(Pharmacy entity)
        {

            try
            {

                Dbcontexts.Pharmacies.Remove(entity);
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
        }
        public Pharmacy Get(Predicate<Pharmacy> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return Dbcontexts.Pharmacies[0];
                }
                else
                {
                    return Dbcontexts.Pharmacies.Find(filter);
                }

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }
        }
        public List<Pharmacy> GetAll(Predicate<Pharmacy> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return Dbcontexts.Pharmacies;

                }
                else
                {
                    return Dbcontexts.Pharmacies.FindAll(filter);
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }

        }
        public void Update(Pharmacy entity)
        {

            try
            {
                var pharmacy = Dbcontexts.Pharmacies.Find(a => a.ID == entity.ID);
                if (pharmacy != null)
                {

                    pharmacy.ID = entity.ID;
                    pharmacy.Name = entity.Name;
                    pharmacy.Address = entity.Address;
                    pharmacy.ContactNumber = entity.ContactNumber;
                    pharmacy.Owner = entity.Owner;
                    pharmacy.Apothecaries = entity.Apothecaries;



                }

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }

        }
     

    }
}










