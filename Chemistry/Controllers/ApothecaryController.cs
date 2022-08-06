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
                    result=byte.TryParse(experience, out experiencee);
                    if (result)
                    {
                        if (experiencee != 0 && experiencee !> apothecaryAge)
                        {
                            PharmacyList: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "All pharamcies");
                            foreach (var pharmacy in pharmacies)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, pharmacy.Name);

                            }
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
    }
}
                


           


               

