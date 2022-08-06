using Core.Constants;
using DataAccess.Helpers;
using DataAccess.Repositories.Implementations;
using Manage.Controllers;
using System;
namespace Manage
{
    class Program
    {
        static void Main()
        {
            AdminController _adminController = new AdminController();
            AdminRepository _adminRepository = new AdminRepository();
            //ApothecaryController _apothecaryController = new ApothecaryController();
            ApothecaryRepository _apothecaryRepository = new ApothecaryRepository();
            //MedicineController _medicineController = new MedicineController();
            MedicineRepository _medicineRepository = new MedicineRepository();
            //OwnerController _ownerController = new OwnerController();
            OwnerRepository _ownerRepository = new OwnerRepository();
            //PharmacyController _pharmacyController = new PharmacyController();
            PharmacyRepository _pharmacyRepository = new PharmacyRepository();


        Logout: var admin = _adminController.Autenticate();


            if (admin != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Welcome , {admin.UserName}");
                Console.WriteLine();
                Initial: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Select one of the options");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "1-Owner");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "2-Pharmacy");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "3-Apothecary");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "4-Medicine");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "5-Logout");
                string number = Console.ReadLine();
                while (true)
                {

                    while (true)
                    {

                        if (number == "1")
                        {
                            OwnerController _ownerController = new OwnerController();
                            while (true)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Select one of the options");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "1-Create Owner");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "2-Update Owner");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "3-Delete Owner");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "4-Get All");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "5-Exit");
                                string number1 = Console.ReadLine();
                                int selected;
                                bool result = int.TryParse(number1, out selected);
                                if (result)
                                {
                                    if (selected > 0 && selected < 7)
                                    {
                                        switch (selected)
                                        {

                                            case (int)Options.CreateOwner:
                                                _ownerController.CreateOwner();
                                                break;

                                            case (int)Options.UpdateOwner:
                                                _ownerController.UpdateOwner();
                                                break;
                                            case (int)Options.DeleteOwner:
                                                _ownerController.DeleteOwner();
                                                break;

                                            case (int)Options.GetAll:
                                                _ownerController.GetAll();
                                                break;
                                            case (int)Options.Exit:
                                                goto Initial;
                                                break;

                                        }

                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number!!");
                                    }
                                }
                                else
                                {

                                    goto Logout;
                                }
                            }
                        }
                        else if (number == "2")
                        {

                            PharmacyController _pharmacyController = new PharmacyController();
                            while (true)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Select one of the options");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "1-Create Pharmacy");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "2-Update Pharmacy");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "3-Delete Pharmacy");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "4-GetAll");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "5-Get All Pharmacies by Owner");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "6-Sale");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "7-Exit");

                                string number1 = Console.ReadLine();
                                int selectedOption;
                                bool result = int.TryParse(number1, out selectedOption);
                                if (result)
                                {
                                    if (selectedOption > 0 && selectedOption <= 7)
                                    {

                                        switch (selectedOption)
                                        {

                                            case (int)Options1.CreatePharmacy:
                                                _pharmacyController.CreatePharmacy();
                                                break;
                                            case (int)Options1.UpdatePharmacy:
                                                _pharmacyController.UpdatePharmacy();
                                                break;
                                            case (int)Options1.DeletePharmacy:
                                                _pharmacyController.DeletePharmacy();
                                                break;
                                            case (int)Options1.GetAll:
                                                _pharmacyController.GetAll();
                                                break;
                                            case (int)Options1.GetAllPharmaciesbyOwner:
                                                _pharmacyController.GetAllPharmaciesByOwner();
                                                break;
                                            case (int)Options1.Sale:
                                                _pharmacyController.Sale();
                                                break;
                                            case (int)Options1.Exit:
                                                goto Initial;
                                                    break;


                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number!!");

                                    }
                                }
                                else
                                {

                                    goto Logout;
                                }
                            }

                        }
                        else if (number == "3")
                        {
                            ApothecaryController _apothecaryController = new ApothecaryController();
                            while (true)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Select one of the options");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "1-Create Apothecary");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "2-Update Apothecary");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "3-Delete Apothecary");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "4-GetAll");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "5-Get All Apothecary By Pharmacy");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "6-Exit");

                                string number1 = Console.ReadLine();
                                int selected;
                                bool result = int.TryParse(number1, out selected);
                                if (result)
                                {
                                    if (selected > 0 && selected <= 6)
                                    {
                                        switch (selected)
                                        {

                                            case (int)Options2.CreateApothecary:
                                                _apothecaryController.CreateApothecary();
                                                break;

                                            case (int)Options2.UpdateApothecary:
                                                _apothecaryController.UpdateApothecary();
                                                break;
                                            case (int)Options2.DeleteApothecary:
                                                _apothecaryController.DeleteApothecary();
                                                break;
                                            case (int)Options2.GetAll:
                                                _apothecaryController.GetAll();
                                                break;
                                            case (int)Options2.GetAllApothecaryByPharmacy:
                                                _apothecaryController.GetAllApothecaryByPharmacy();
                                                break;
                                            case (int)Options2.Exit:
                                                goto Initial;
                                                break;

                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number!!");

                                    }
                                }
                                else
                                {
                                    goto Logout;
                                }

                            }
                        }
                        else if (number == "4")
                        {

                            MedicineController _medicineController = new MedicineController();
                            while (true)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Select one of the options");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "1-Create Medicine");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "2-Update Medicine");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "3-Delete Medicine");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "4-GetAll");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "5-Get All Medicines By Pharmacy");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "6-Filter");
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "7-Exit");


                                string number1 = Console.ReadLine();
                                int selected;
                                bool result = int.TryParse(number1, out selected);
                                if (result)
                                {
                                    if (selected > 0 && selected <= 7)
                                    {
                                        switch (selected)
                                        {

                                            case (int)Options3.CreateMedicine:
                                                _medicineController.CreateMedicine();
                                                break;
                                            case (int)Options3.UpdateMedicine:
                                                _medicineController.UpdateMedicine();
                                                break;
                                            case (int)Options3.DeleteMedicine:
                                                _medicineController.DeleteMedicine();
                                                break;
                                            case (int)Options3.GetAll:
                                                _medicineController.GetAll();
                                                break;
                                            case (int)Options3.GetAllMediciniesByPharmacy:
                                                _medicineController.GetAllMediciniesByPharmacy();
                                                break;
                                            //case (int)Options3.Filter:
                                            //    _medicineController.Filter();
                                            //    break;
                                            case (int)Options3.Exit:
                                                goto Initial;
                                                break;


                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number!!");
                                    }
                                }
                                else
                                {

                                    goto Logout;
                                }


                            }



                        }
                    }



                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Password or username were entered false,please try again");
                goto Logout;
            }

        }

    }
}





