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
            if (owners.Count > 0)
            {


            AllOwnersList: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "All owners");

                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, $" ID: {owner.ID},Name:{owner.Name}");


                }

            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please choose  owner by  id");
                string ownerid = Console.ReadLine();
                int id;
                bool result = int.TryParse(ownerid, out id);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.ID == id);
                    if (owner != null)
                    {

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter pharmacy name:");
                        string name = Console.ReadLine();

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter pharmacy address:");
                        string address = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter pharmacy contactnumber:");
                        string contactnumber = Console.ReadLine();


                        Pharmacy pharmacy = new Pharmacy
                        {
                            Name = name,
                            Address = address,
                            ContactNumber = contactnumber,
                            Owner = owner,

                        };


                        _pharmacyRepository.Create(pharmacy);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"ID:{pharmacy.ID},Name;{pharmacy.Name},Address:{pharmacy.Address} and phramcy's owner:{owner.Name}");



                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Including owner doesn't exist");
                        goto AllOwnersList;

                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter Id in digits");
                    goto ID;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please create owner before inputing info about pharmacy");

            }
        }
        public void UpdatePharmacy()
        {

            GetAll();
        ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter pharmacy's ID");
            string ID = Console.ReadLine();
            int Id;
            bool result = int.TryParse(ID, out Id);
            if (result)
            {
                var pharmacyid = _pharmacyRepository.Get(p => p.ID == Id);
                if (pharmacyid != null)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new pharmacy name:");
                    string newname = Console.ReadLine();
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new pharmacy address:");
                    string newaddress = Console.ReadLine();
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new pharmacy contactnumber:");
                    string newcontactnumber = Console.ReadLine();
                Owner: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new owner's id");
                    string newowner = Console.ReadLine();
                    int ownerid;
                    result = int.TryParse(newowner, out ownerid);
                    if (result)
                    {
                        var newOwner = _ownerRepository.Get(n => n.ID == ownerid);
                        if (newOwner != null)
                        {
                            var newpharmacy = new Pharmacy
                            {
                                ID = ownerid,
                                Name = newname,
                                Address = newaddress,
                                ContactNumber = newcontactnumber


                            };
                            _pharmacyRepository.Update(newpharmacy);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id - {newpharmacy.ID},Name - {newname},Adress-{newaddress},Contactnumber-{newcontactnumber}");

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This owner doesn't exist");
                            goto Owner;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right owner's ID");
                        goto Owner;
                    }


                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right ID");
                    goto ID;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right number");
                goto ID;
            }
        }
        public void GetAll()
        {

            var pharmacies = _pharmacyRepository.GetAll();

            if (pharmacies.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "All pharmacies list");

                foreach (var pharmacy in pharmacies)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id - {pharmacy.ID},Name - {pharmacy.Name},Adress-{pharmacy.Address},Contactnumber-{pharmacy.ContactNumber},Owner-{pharmacy.Owner.Name},Owner's Id:{pharmacy.Owner.ID}");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no pharmacy,please create it ");
            }
        }
        public void DeletePharmacy()
        {
            GetAll();
        ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter the ID of the pharmacy you want to delete ");
            string ID = Console.ReadLine();
            int Id;

            bool result = int.TryParse(ID, out Id);
            if (result)
            {
            var pharmacy = _pharmacyRepository.Get(p => p.ID == Id);

            if (pharmacy != null)
            {
                _pharmacyRepository.Delete(pharmacy);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Pharmacy with ID:{pharmacy.ID} is deleted");



            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Pharmacy with this ID  doesn't exist");
                goto ID;
            }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right number");
                goto ID;
            }

        }
        //public void GetAllPharmaciesByOwner()
        //{
            //var pharmacies = _pharmacyRepository.GetAll();
            //if(pharmacies.Count > 0)
            //{
            //    var owners = _ownerRepository.GetAll();
            //    if(owners.Count > 0)
            //    {
            //        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please enter owner's id to print it pharmacies");
            //        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Owner's list");
            //        foreach(var owner in owners)
            //        {
            //            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray,$"ID:{owner.ID},Name:{owner.Name},Surname:{owner.Surname}");
            //            string id = Console.ReadLine();
            //            int Id;
            //            bool result=int.TryParse(id, out Id);
            //            if (result)
            //            {
            //               var ownerr = _ownerRepository.Get(o => o.ID == Id);
            //                if(ownerr != null)
            //                {
            //                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, $"All pharmacies owned by {owner.Name} {owner.Surname}");
            //                    if(ownerr.Pharmacies.Count > 0)
            //                    {
            //                        foreach(var ownerpharmacy in ownerr.Pharmacies) 
            //                        {
            //                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, $"Pharamcy's ID:{ownerpharmacy.ID},Name:{ownerpharmacy.Name},Address:{ownerpharmacy.Address},ContactNumber:{ownerpharmacy.ContactNumber}");
            //                        }
            //                    }
            //                    else
            //                    {
            //                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"There is no pharmacy belonged to owner {ownerr.Name} {ownerr.Surname}");
            //                    }
            //                }
            //                else
            //                {
            //                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no owner with this id");
            //                }
            //            }
            //            else
            //            {
            //                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter number");
            //                goto ID;
            //            }



            //        }

            //    }
            //else
            //{
            //    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no owner please create it");
            //}
            //}
            //else
            //{
            //    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no pharmacy");
            //}
        //}







    }
}













