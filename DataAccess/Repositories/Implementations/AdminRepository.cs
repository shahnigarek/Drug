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
    public class AdminRepository : IRepository<Admin>
    {
        private static int id;
        public Admin Create(Admin entity)
        {

            id++;
            entity.ID = id;
            try
            {
                Dbcontexts.Admins.Add(entity);

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
            return entity;

        }

        public void Delete(Admin entity)
        {
            try
            {

                Dbcontexts.Admins.Remove(entity);
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
        }

        public Admin Get(Predicate<Admin> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return Dbcontexts.Admins[0];
                }
                else
                {
                    return Dbcontexts.Admins.Find(filter);
                }

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }

        }

        public List<Admin> GetAll(Predicate<Admin> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return Dbcontexts.Admins;

                }
                else
                {
                    return Dbcontexts.Admins.FindAll(filter);
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public void Update(Admin entity)
        {
            try
            {
                var admin = Dbcontexts.Admins.Find(a => a.ID == entity.ID);
                if (admin != null)
                {

                    admin.UserName = entity.UserName;
                    admin.Password = entity.Password;

                }

            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
        }

    }
}
