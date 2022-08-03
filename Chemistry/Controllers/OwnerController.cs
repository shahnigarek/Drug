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
           
                Owner owner = new Owner
                {

                    Name = name,
                    Surname = surname
                };
                var owner1 = _ownerRepository.Create(owner);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Owner-{owner1.Name},owner's ID-{owner1.ID} with surname-{owner1.Surname}  was successufully created");
            
           

        }
        //public void UpdateOwner()
        //{

        //    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter owner's ID");
        //    string ID = Console.ReadLine();
        //    int Id;
        //    bool result = int.TryParse(ID, out Id);

        //    var owner1 = _ownerRepository.Get(o => o.ID == Id);
        //    if (owner1 != null)
        //    {

        //        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new owner's name:");
        //        string newname = Console.ReadLine();
        //        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new owner's surname:");
        //        string newsurname = Console.ReadLine();
               
        //        if (result)

        //        {

        //            var newtutor = new Teacher
        //            {
        //                ID = tutorid.ID,
        //                Name = newname,
        //                Surname = newsurname,
        //                Age = age
        //            };
        //            _teacherRepository.Update(newtutor);
        //            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{tutorid.Name},Surname:{tutorid.Surname},Age:{newtutor.Age} is updated to Name: {newtutor.Name}, Surname: {newtutor.Surname},Age:{newtutor.Age} ");
        //        }
        //        else
        //        {
        //            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter number");
        //        }
        //    }

        //    else
        //    {
        //        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct ID of teacher");
        //    }

        //}

    }
}

