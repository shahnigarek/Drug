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





