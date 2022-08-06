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
    public class MedicineController
    {
        private MedicineRepository _medicineRepository;
        private PharmacyRepository _pharmacyRepository;
        public MedicineController()
        {
            _medicineRepository = new MedicineRepository();
            _pharmacyRepository = new PharmacyRepository();
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

            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please choose  pharmacy by  id");
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


                                    _medicineRepository.Create(medicine);
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"ID:{medicine.ID},Name:{medicine.Name},Price:{medicine.Price},Count:{medicine.Count} and pharmacy to which belonged medicine:{medicine.Pharmacy.Name}");



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
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no medicine please create it");
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "All medicines list");

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
            var medicines = _medicineRepository.GetAll();
            if (medicines.Count > 0)
            {
                var pharmacies = _pharmacyRepository.GetAll();
                if (pharmacies.Count > 0)
                {
                ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please enter pharmacy's id to print it medicines");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Pharmacy's list");
                    foreach (var pharmacy in pharmacies)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, $"ID:{pharmacy.ID},Name:{pharmacy.Name},Address:{pharmacy.Address},ContactNumber:{pharmacy.ContactNumber}");
                        string id = Console.ReadLine();
                        if (id != null)
                        {
                            int Id;
                            bool result = int.TryParse(id, out Id);
                            if (result)
                            {
                                var pharmacyy = _pharmacyRepository.Get(p => p.ID == Id);
                                if (pharmacyy != null)
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, $"All medicines exist in Pharmacy: {pharmacy.Name} Address: {pharmacy.Address} ContactNumber:{pharmacy.ContactNumber}");
                                    if (pharmacy.Medicines.Count > 0)
                                    {
                                        foreach (var medicinepharmacy in pharmacy.Medicines)
                                        {
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, $"Medicine's ID:{medicinepharmacy.ID},Name:{medicinepharmacy.Name},Price:{medicinepharmacy.Price},Count:{medicinepharmacy.Count}");
                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"There is no medicine belonged to pharmacy {pharmacy.Name} {pharmacy.ID}");
                                    }
                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no pharmacy with this id");
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
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right number");

                        }

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no pharmacy please create it");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no medicine");
            }
        }
    }
}






