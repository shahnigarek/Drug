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
            ApothecaryController _apothecaryController = new ApothecaryController();
            ApothecaryRepository _apothecaryRepository = new ApothecaryRepository();
            MedicineController _medicineController = new MedicineController();
            MedicineRepository _medicineRepository = new MedicineRepository();
            OwnerController _ownerController = new OwnerController();
            OwnerRepository _ownerRepository = new OwnerRepository();
            PharmacyController _pharmacyController = new PharmacyController();
            PharmacyRepository _pharmacyRepository = new PharmacyRepository();

        Authentication: var admin = _adminController.Autenticate();


            if (admin != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Welcome , {admin.UserName}");
                Console.WriteLine();

                while (true)
                {

                }
            }
        }
    }
}
