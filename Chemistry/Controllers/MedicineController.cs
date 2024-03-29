﻿using Core.Entities;
using DataAccess.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    public class MedicineController
    {
        private MedicineRepository _medicineRepository;
        private PharmacyRepository _pharmacyRepository;
        public MedicineController()
        {
            _medicineRepository = new MedicineRepository();
            _pharmacyRepository = new PharmacyRepository();
        }
        public void UpdateMedicine()
        {
            GetAll();
        ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter medicine's ID");
            string ID = Console.ReadLine();
            int Id;
            bool result = int.TryParse(ID, out Id);
            if (result)
            {
                var medicine = _medicineRepository.Get(m => m.ID == Id);
                if (medicine != null)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new medicine name:");
                    string newname = Console.ReadLine();
                Price: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter medicine price:");
                    string price = Console.ReadLine();
                    double pricemedicine;
                    result = double.TryParse(price, out pricemedicine);
                    if (result)
                    {
                    Count: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter medicine count:");
                        string count = Console.ReadLine();
                        int countmedicine;
                        result = int.TryParse(count, out countmedicine);
                        if (result)
                        {
                            if (countmedicine > 0)
                            {
                                var pharmacies = _pharmacyRepository.GetAll();
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All pharmacies list");
                                foreach(var pharmacy in pharmacies)
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, $"Id - {pharmacy.ID},Name - {pharmacy.Name},Adress-{pharmacy.Address},Contactnumber-{pharmacy.ContactNumber},Owner-{pharmacy.Owner.Name},Owner's Id:{pharmacy.Owner.ID}");
                                }

                            Pharmacy: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new pharmacy's id");
                                string newpharmacy = Console.ReadLine();
                                int pharmacyid;
                                result = int.TryParse(newpharmacy, out pharmacyid);
                                if (result)
                                {
                                    var newPharmacy = _pharmacyRepository.Get(p => p.ID == pharmacyid);
                                    if (newPharmacy != null)
                                    {
                                        var newmedicine = new Medicine
                                        {
                                            ID = pharmacyid,
                                            Name = newname,
                                            Price = pricemedicine,
                                            Count = countmedicine


                                        };
                                        _medicineRepository.Update(newmedicine);
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id - {newmedicine.ID},Name - {newname},Price-{pricemedicine},Count-{countmedicine}");

                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This  pharmacy doesn't exist");
                                        goto Pharmacy;
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right medicine's ID");
                                    goto Pharmacy;
                                }


                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right ID");
                                goto Count;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right number");
                            goto Count;
                        }

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right number");
                        goto Price;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no medicine.Please create it");
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
            var medicines = _medicineRepository.GetAll();

            if (medicines.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "All medicine's list");

                foreach (var medicine in medicines)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id - {medicine.ID},Name - {medicine.Name},Price-{medicine.Price},Count-{medicine.Count},Pharmacy-{medicine.Pharmacy.Name},Pharmacy's Id:{medicine.Pharmacy.ID}");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no medicine,please create it ");
            }
        }
        public void DeleteMedicine()
        {
            GetAll();
        ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter the ID of the medicine you want to delete ");
            string ID = Console.ReadLine();
            int Id;

            bool result = int.TryParse(ID, out Id);
            if (result)
            {
                var medicine = _medicineRepository.Get(m => m.ID == Id);

                if (medicine != null)
                {
                    _medicineRepository.Delete(medicine);
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Pharmacy with ID:{medicine.ID} is deleted");



                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Medicine with this ID  doesn't exist");
                    goto ID;
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right number");
                goto ID;
            }
        }
        public void GetAllMediciniesByPharmacy()
        {

            var pharmacies = _pharmacyRepository.GetAll();
            if (pharmacies.Count > 0)
            {
            All: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Pharmacy's list");
                foreach (var pharmacy in pharmacies)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, $"ID:{pharmacy.ID},Name:{pharmacy.Name},Address:{pharmacy.Address},ContactNumber:{pharmacy.ContactNumber}");
                }

            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please enter pharmacy's id to print it medicines");
                string pharmacyid = Console.ReadLine();
                int Id;
                bool result = int.TryParse(pharmacyid, out Id);
                if (result)
                {
                    var pharmacy = _pharmacyRepository.Get(p => p.ID == Id);
                    if (pharmacy != null)
                    {
                        var medicines = _medicineRepository.GetAll(m => m.Pharmacy != null ? m.Pharmacy.ID == pharmacy.ID : false);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, $"All medicines exist in Pharmacy: {pharmacy.Name} Address: {pharmacy.Address} ContactNumber:{pharmacy.ContactNumber}");
                        foreach (var medicine in medicines)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, $"Medicine's ID:{medicine.ID},Name:{medicine.Name},Price:{medicine.Price},Count:{medicine.Count}");
                        }

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no medicine like that");
                        goto All;
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no pharmacy please create it");
            }

        }
        public void Filter()
        {
            var medicinies = _medicineRepository.GetAll();
            if (medicinies.Count > 0)
            {

            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter maximum price of drugs you want:");
                string price = Console.ReadLine();
                double maxprice;
                bool result = double.TryParse(price, out maxprice);
                if (result)
                {
                    medicinies = _medicineRepository.GetAll(m => m.Price <= maxprice);
                    if (medicinies.Count > 0)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"All medicines costing less or equal to {maxprice}");
                        foreach (var medicine in medicinies)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"id: {medicine.ID}, name : {medicine.Name}," +
                                $" price{medicine.Price}, count : {medicine.Count}");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "no medicine found costing less than the max price");
                    }


                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "enter right number");
                    goto id;
                }


            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no medicine please create it");
            }
        }
        public void CreateMedicine()
        {
            var pharmacies = _pharmacyRepository.GetAll();
            if (pharmacies.Count > 0)
            {


            AllPharmaciesList: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "All pharmacies");

                foreach (var pharmacy in pharmacies)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, $" ID: {pharmacy.ID},Name:{pharmacy.Name}");


                }

            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please choose  pharmacy by its id");
                string pharmacyid = Console.ReadLine();
                int id;
                bool result = int.TryParse(pharmacyid, out id);
                if (result)
                {
                    var pharmacy = _pharmacyRepository.Get(p => p.ID == id);
                    if (pharmacy != null)
                    {

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter medicine name:");
                        string name = Console.ReadLine();

                    Price: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter medicine price:");
                        string price = Console.ReadLine();
                        double pricemedicine;
                        result = double.TryParse(price, out pricemedicine);
                        if (result)
                        {
                        Count: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter medicine count:");
                            string count = Console.ReadLine();
                            int countmedicine;
                            result = int.TryParse(count, out countmedicine);
                            if (result)
                            {
                                if (countmedicine > 0)
                                {
                                    Medicine medicine = new Medicine
                                    {
                                        Name = name,
                                        Price = pricemedicine,
                                        Count = countmedicine,
                                        Pharmacy = pharmacy,

                                    };

                                    pharmacy.Medicines.Add(medicine);
                                    _medicineRepository.Create(medicine);
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"ID:{medicine.ID},Name:{medicine.Name},Price:{medicine.Price},Count:{medicine.Count} and pharmacy to which belonges medicine:{medicine.Pharmacy.Name}");
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right number");
                                    goto Count;
                                }

                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right number");
                                goto Count;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right number");
                            goto Price;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Including pharmacy doesn't exist");
                        goto AllPharmaciesList;

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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please create pharmacy before inputing info about medicine");

            }
        }




    }

}






