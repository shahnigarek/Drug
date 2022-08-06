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
        private MedicineRepository _medicineRepository;

        public PharmacyController()
        {
            _ownerRepository = new OwnerRepository();
            _pharmacyRepository = new PharmacyRepository();
            _medicineRepository = new MedicineRepository();
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
                        owner.Pharmacies.Add(pharmacy);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"ID:{pharmacy.ID},Name;{pharmacy.Name},Address:{pharmacy.Address},Contactnumber:{pharmacy.ContactNumber} and phramcy's owner:{owner.Name}");



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
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id - {pharmacy.ID},Name - {pharmacy.Name},Adress-{pharmacy.Address},Contactnumber-{pharmacy.ContactNumber},Owner-{pharmacy.Owner.Name},Owner's Id:{pharmacy.Owner.ID},Count:{pharmacy.Medicines.Count}");
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
        public void GetAllPharmaciesByOwner()
        {
            var pharmacies = _pharmacyRepository.GetAll();
            if (pharmacies.Count > 0)
            {
                var owners = _ownerRepository.GetAll();
                if (owners.Count > 0)
                {
                ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please enter owner's id to print it pharmacies");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Owner's list");
                    foreach (var owner in owners)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, $"ID:{owner.ID},Name:{owner.Name},Surname:{owner.Surname}");
                        string id = Console.ReadLine();
                        if (id != null)
                        {
                            int Id;
                            bool result = int.TryParse(id, out Id);
                            if (result)
                            {
                                var ownerr = _ownerRepository.Get(o => o.ID == Id);
                                if (ownerr != null)
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, $"All pharmacies owned by {owner.Name} {owner.Surname}");
                                    if (owner.Pharmacies.Count > 0)
                                    {
                                        foreach (var ownerpharmacy in owner.Pharmacies)
                                        {
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, $"Pharamcy's ID:{ownerpharmacy.ID},Name:{ownerpharmacy.Name},Address:{ownerpharmacy.Address},ContactNumber:{ownerpharmacy.ContactNumber}");
                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"There is no pharmacy belonged to owner {owner.Name} {owner.Surname}");
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no owner with this id");
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter number");
                                goto ID;
                            }



                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter riht number");

                        }

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no owner please create it");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no pharmacy");
            }

        }
        public void Sale()
        {
            var pharmacies = _pharmacyRepository.GetAll();

            if (pharmacies.Count > 0)
            {
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please choose one of the pharmacy by id");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Pharmacy List");
                foreach (var pharmacy in pharmacies)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, $"Pharmacy's ID:{pharmacy.ID},Name:{pharmacy.Name},Address:{pharmacy.Address},ContactNumber:{pharmacy.ContactNumber},Owner:{pharmacy.Owner.Name}");
                }
                string id = Console.ReadLine();
                int choosenId;
                bool result = int.TryParse(id, out choosenId);
                if (result)
                {
                    var pharmacy = _pharmacyRepository.Get(p => p.ID == choosenId);
                    if (pharmacy != null)
                    {

                        var medicines = _medicineRepository.GetAll(m => m.Pharmacy.Medicines == pharmacy.Medicines);
                        if (medicines.Count > 0)
                        {
                            foreach (var medicine in medicines)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, $"Medicine ID:{medicine.ID},Name:{medicine.Name},Price:{medicine.Price},Count:{medicine.Count}");
                            }
                        ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please,choose medicine by ID");
                            string ID = Console.ReadLine();
                            int medicineid;
                            result = int.TryParse(ID, out medicineid);
                            if (result)
                            {
                                var medicine = _medicineRepository.Get(m => m.ID == medicineid);
                                if (medicine != null)
                                {
                                Count: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Please,enter medicine's count");

                                    if (medicine.Count > 0)
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter medicine count you want to buy");
                                        string count = Console.ReadLine();
                                        int medicinecount;
                                        result = int.TryParse(count, out medicinecount);
                                        if (result)
                                        {

                                            if (medicine.Count >= medicinecount)
                                            {
                                                double totalPrice = medicine.Price * medicinecount;
                                            PRICE: ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Please pay total price if you wan to buy the medicine, total price : {totalPrice}");
                                                string total = Console.ReadLine();
                                                double totalD;
                                                result = double.TryParse(total, out totalD);
                                                if (result)
                                                {
                                                    if (totalD == totalPrice)
                                                    {
                                                        medicine.Count -= medicinecount;
                                                        medicine.Count = medicine.Count;
                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "This medicine sold");
                                                    }
                                                    else
                                                    {
                                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "You have not provided exact money to buy the medicine ");
                                                        
                                                    }

                                                }
                                                else
                                                {
                                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter medicine price in correct format");
                                                    goto PRICE;
                                                }
                                            }
                                            else
                                            {
                                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is not enough medicine to sell");

                                            }

                                        }
                                        else
                                        {
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter in number");
                                            goto Count;
                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "No medicine  to sell");

                                    }
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter number");
                                goto ID;
                            }

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no medicine please create it");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "No pharmacy found with this id");

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "please enter id in correct digit");
                    goto id;
                }


            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no pharmacy please create it");
            }
        }








    }
}













