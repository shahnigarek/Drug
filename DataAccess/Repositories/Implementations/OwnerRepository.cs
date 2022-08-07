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
    public class OwnerRepository : IRepository<Owner>
    {
        private static int id;

        public Owner Create(Owner entity)
        {
            id++;
            entity.ID = id;
            try
            {
                Dbcontexts.Owners.Add(entity);

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
            return entity;
        }

        public void Delete(Owner entity)
        {
            try
            {

                Dbcontexts.Owners.Remove(entity);
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
        }

        public Owner Get(Predicate<Owner> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return Dbcontexts.Owners[0];
                }
                else
                {
                    return Dbcontexts.Owners.Find(filter);
                }

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public List<Owner> GetAll(Predicate<Owner> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return Dbcontexts.Owners;

                }
                else
                {
                    return Dbcontexts.Owners.FindAll(filter);
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public void Update(Owner entity)
        {
            try
            {
                var owner = Dbcontexts.Owners.Find(a => a.ID == entity.ID);
                if (owner != null)
                {
                    owner.ID = entity.ID;
                    owner.Name = entity.Name;
                    owner.Surname = entity.Surname;
                    owner.Pharmacies = entity.Pharmacies;
                }
            }

            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
        }
    }
}

      

                    
