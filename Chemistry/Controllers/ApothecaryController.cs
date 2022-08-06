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
    public class ApothecaryController
    {
        private ApothecaryRepository _apothecaryRepository;
        private PharmacyRepository _pharmacyRepository;
        public ApothecaryController()
        {
            _apothecaryRepository = new ApothecaryRepository();
            _pharmacyRepository = new PharmacyRepository();
        }
        public void CreateApothecary()
        {
            var pharmacies = _pharmacyRepository.GetAll();
            if (pharmacies.Count != 0)
            {
            PharmacyList: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "All pharmacies");
                foreach (var pharmacy in pharmacies)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, pharmacy.Name);

                }
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter apothecary's name");
                string name = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter apothecary's surname");
                string surname = Console.ReadLine();
            Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter apothecary's age");
                string age = Console.ReadLine();
                byte apothecaryAge;
                bool result = byte.TryParse(age, out apothecaryAge);
                if (result)
                {
                Experience: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter apothecary's experience");
                    string experience = Console.ReadLine();
                    byte experiencee;
                    result = byte.TryParse(experience, out experiencee);
                    if (result)
                    {
                        if (experiencee > 0 && experiencee <= apothecaryAge)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Enter pharamcy's name");
                            string pharmacyName = Console.ReadLine();
                            var pharmacyname = _pharmacyRepository.Get(p => p.Name.ToLower() == pharmacyName.ToLower());
                            if (pharmacyName != null)
                            {

                                var apothecary = new Apothecary
                                {
                                    Name = name,
                                    Surname = surname,
                                    Age = apothecaryAge,
                                    Experience = experiencee

                                };
                                _apothecaryRepository.Create(apothecary);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"ID:{apothecary.ID},Name;{apothecary.Name},Surname:{apothecary.Surname},Age:{apothecary.Age},Experience:{apothecary.Experience}");
                            }
                            else
                            {

                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no phramacy name like that please enter right name ");
                                goto PharmacyList;
                            }

                        }
                        else
                        {

                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Experience mustn't be bigger than Age!!!!");
                            goto Experience;
                        }



                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right number");
                        goto Experience;

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter right number");
                    goto Age;
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no pharmacy please create it");
            }
        }
        public void UpdateApothecary()
        {
        ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter apothecary's ID");
            string ID = Console.ReadLine();
            int Id;
            bool result = int.TryParse(ID, out Id);
            if (result)
            {
                var apothecary = _apothecaryRepository.Get(t => t.ID == Id);
                if (apothecary != null)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new apothecary's name:");
                    string newname = Console.ReadLine();
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new apothecary's surname:");
                    string newsurname = Console.ReadLine();
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new apothecary's age");
                    string age = Console.ReadLine();
                    byte newage;
                    result = byte.TryParse(age, out newage);
                    if (result)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter apothecary's experience");
                        string experience = Console.ReadLine();
                        byte newexperience;
                        result = byte.TryParse(experience, out newexperience);
                        if (result)
                        {
                            if (newexperience > 0 && newexperience <= newage)
                            {
                                var newapothecary = new Apothecary
                                {
                                    ID = apothecary.ID,
                                    Name = newname,
                                    Surname = newsurname,
                                    Age = newage,
                                    Experience = newexperience

                                };
                                _apothecaryRepository.Update(newapothecary);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name,Surname,Age,Experience  is successufully updated to Name: {newapothecary.Name} Surname: {newapothecary.Surname} Age:{apothecary.Age} Experience :{apothecary.Experience} ");

                            }

                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct ID of apothecary");
                                goto ID;
                            }
                        }

                    }
                }

            }
        }
    }
}









