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
    public class OwnerController
    {
        private OwnerRepository _ownerRepository;

        public OwnerController()
        {
            _ownerRepository = new OwnerRepository();
        }
        public void CreateOwner()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter owner's name:");
            string name = Console.ReadLine();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter owner's surname");
            string surname = Console.ReadLine();
           Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter owner's age");
            string age = Console.ReadLine();
            byte ownerAge;
            bool result = byte.TryParse(age, out ownerAge);
            if (result)
            {
                Owner owner = new Owner
                {

                    Name = name,
                    Surname = surname
                };
                var owner1 = _ownerRepository.Create(owner);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Owner-{owner1.Name},owner's ID-{owner1.ID} with surname-{owner1.Surname}  was successufully created");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right number");
                goto Age;
            }

        }
    }
}
