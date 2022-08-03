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
        public void UpdateOwner()
        {
            
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter owner's ID");
            string ID = Console.ReadLine();
            int Id;
            bool result = int.TryParse(ID, out Id);
            if (result)
            {
               var ownerid = _ownerRepository.Get(o => o.ID == Id);
                if(ownerid != null)
                {
               
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new owner's name:");
                    string newname = Console.ReadLine();
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new owner's surname:");
                    string newsurname = Console.ReadLine();

                    var newOwner = new Owner
                    {
                        ID=ownerid.ID,
                        Name = newname,
                        Surname = newsurname,

                    };
                    _ownerRepository.Update(newOwner);
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Owner is updated to Name: {newOwner.Name} and  Surname: {newOwner.Surname}" );

                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct ID of owner");
            }

        }
        public void DeleteOwner()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter the ID of the owner you want to delete ");
            string ID = Console.ReadLine();
            int Id;

            bool result = int.TryParse(ID, out Id);

            var owner = _ownerRepository.Get(o => o.ID == Id);

            if (owner != null)
            {
                _ownerRepository.Delete(owner);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Teacher with ID:{owner.ID} is deleted");



            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Owner with this ID  doesn't exist");
            }
        }
    }
}
            



                   

               
                

