using Core.Entities;
using DataAccess.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    public class PharmacyController
    {
        private OwnerRepository _ownerRepository;
        private PharmacyRepository _pharmacyRepository;  

        public PharmacyController()
        {
            _ownerRepository = new OwnerRepository();
            _pharmacyRepository = new PharmacyRepository();
        }
        public void CreatePharmacy()
        {

            var owners = _ownerRepository.GetAll();
            if (owners.Count != 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter paharmacy name");
                string name = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter pharmacy address");
                string address = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter pharmacy contactnumber");
                string number = Console.ReadLine();
                byte contactnumber;
                bool result = byte.TryParse(number, out contactnumber);

            AllOwnersList: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "All owners");

                foreach (var owner in owners)
                { 
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, owner.Name);
                   
                }

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter owner's name");
                string ownerName = Console.ReadLine();

                var ownername = _ownerRepository.Get(o => o.Name.ToLower() == ownerName.ToLower());
                if (ownerName != null)
                {
                    
                        var pharmacy = new Pharmacy
                        {
                           Name = name,
                          Address=address,
                          ContactNumber=contactnumber,

                        };
                       

                        _pharmacyRepository.Create(pharmacy);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"ID:{pharmacy.ID},Name;{pharmacy.Name},Address:{pharmacy.Address} and phramcy's owner:{ownerName}");
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Including owner doesn't exist");
                    goto AllOwnersList;

                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please create owner before inputing info about pharmacy");
            }

        }
    }

}
                    
                   



        
