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
                string contactnumber = Console.ReadLine();


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
                        Address = address,
                        ContactNumber = contactnumber

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
        //public void UpdatePharmacy()
        //{

        //    GetAll();
        //    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter pharmacy's ID");
        //    string ID = Console.ReadLine();
        //    int Id;
        //    bool result = int.TryParse(ID, out Id);

        //    var pharmacyid = _pharmacyRepository.Get(p => p.ID == Id);
        //    if (pharmacyid != null)
        //    {

        //        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new pharmacy name:");
        //        string newname = Console.ReadLine();
        //        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new pharmacy address:");
        //        string newaddress = Console.ReadLine();
        //        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new pharmacy contactnumber:");
        //        string newcontactnumber = Console.ReadLine();
        //        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new owner's name");
        //        string newOwnerName = Console.ReadLine();


        //        if (pharmacyid.Owner.Name.ToLower() == newOwnerName)
        //        {

        //            pharmacyid.Name = newname;
        //            pharmacyid.Address = newaddress;
        //            pharmacyid.ContactNumber = newcontactnumber;
        //            _pharmacyRepository.Update(pharmacyid);



        //        }
        //        else
        //        {
        //            pharmacyid.Name = newname;
        //            pharmacyid.Address = newaddress;
        //            pharmacyid.ContactNumber = newcontactnumber;

        //            var newowner = _ownerRepository.Get(o => o.Name.ToLower() == newOwnerName.ToLower());
        //            if (newowner != null)
        //            {
        //                pharmacyid.Owner = newowner;
        //                _pharmacyRepository.Update(pharmacyid);
        //            }
        //            else
        //            {
        //                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right owner name");

        //            }

        //        }
        //    }
        //    else
        //    {
        //        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right ID");
        //    }
        //}
        public void GetAll()
        {
            var pharamcies = _pharmacyRepository.GetAll();
            var owners = _ownerRepository.GetAll();
            if (pharamcies.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "All pharmacies list");

                foreach (var pharmacy in pharamcies)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id - {pharmacy.ID},Name - {pharmacy.Name},Adress-{pharmacy.Address},Contactnumber-{pharmacy.ContactNumber}");
                }
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Owner-{owner.Name}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no pharmacy,please create it ");
            }
        }
    }
}
                      



                    
                   



        
