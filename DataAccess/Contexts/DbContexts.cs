using Core.Entities;
using DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public static class Dbcontexts
    {
        static Dbcontexts()
        {
            Apothecaries = new List<Apothecary>();
            Medicines = new List<Medicine>();
            Pharmacies = new List<Pharmacy>();
            Owners= new List<Owner>();
            Admins = new List<Admin>();

            string password = "academyapp";
            var hashedPassword = PasswordHasher.Encrypt(password);
            Admin admin1 = new Admin("admin1", hashedPassword);
            Admins.Add(admin1);

            string password1 = "chaand";
            var hashedPassword1 = PasswordHasher.Encrypt(password1);
            Admin admin2 = new Admin("admin2", hashedPassword1);
            Admins.Add(admin2);



        }

        public static List<Pharmacy> Pharmacies { get; set; }
        public static List<Apothecary> Apothecaries { get; set; }
        public static List<Admin> Admins { get; set; }
        public static List<Owner> Owners { get; set; }
        public static List<Medicine> Medicines  { get; set; }   


    }

}
