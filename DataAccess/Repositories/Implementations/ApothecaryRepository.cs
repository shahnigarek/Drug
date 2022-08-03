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
    public class ApothecaryRepository : IRepository<Apothecary>
    {

        private static int id;
        public Apothecary Create(Apothecary entity)
        {
            id++;
            entity.ID = id;
            try
            {
                Dbcontexts.Apothecaries.Add(entity);

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
            return entity;
        }

        public void Delete(Apothecary entity)
        {

            try
            {

                Dbcontexts.Apothecaries.Remove(entity);
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
        }

    

        public Apothecary Get(Predicate<Apothecary> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return Dbcontexts.Apothecaries[0];
                }
                else
                {
                    return Dbcontexts.Apothecaries.Find(filter);
                }

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public List<Apothecary> GetAll(Predicate<Apothecary> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return Dbcontexts.Apothecaries;

                }
                else
                {
                    return Dbcontexts.Apothecaries.FindAll(filter);
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public void Update(Apothecary entity)
        {
            try
            {
                var apothecary = Dbcontexts.Apothecaries.Find(a => a.ID == entity.ID);
                if (apothecary != null)
                {

                    apothecary.ID = entity.ID;
                    apothecary.Surname = entity.Surname;
                    apothecary.Name = entity.Name;
                    apothecary.Age = entity.Age;
                    apothecary.Experience = entity.Experience;
                    apothecary.Pharmacy = entity.Pharmacy;
                    
                }

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
        }
    

        void IRepository<Apothecary>.Create(Apothecary entity)
        {
            throw new NotImplementedException();
        }
    }
}
