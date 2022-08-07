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
            if (pharmacies.Count > 0)
            {
            PharmacyList: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "All pharmacies");
                foreach (var pharmacy in pharmacies)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, $" ID : {pharmacy.ID} Name : {pharmacy.Name}");

                }
            Digits: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please, choose the pharmacy's id to create apothecary in it");
                string Id = Console.ReadLine();
                int choosenId;
                bool result = int.TryParse(Id, out choosenId);
                if (result)
                {
                    var pharmacy = _pharmacyRepository.Get(p => p.ID == choosenId);
                    if (pharmacy != null)
                    {

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter apothecary's name");
                        string name = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter apothecary's surname");
                        string surname = Console.ReadLine();
                    Age: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter apothecary's age");
                        string age = Console.ReadLine();
                        byte apothecaryAge;
                        result = byte.TryParse(age, out apothecaryAge);
                        if (result)
                        {
                        Experience: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter apothecary's experience");
                            string experience = Console.ReadLine();
                            byte experiencee;
                            result = byte.TryParse(experience, out experiencee);
                            if (result)
                            {
                                if (experiencee > 0 && experiencee < apothecaryAge)
                                {
                                    if (experiencee >= 18)
                                    {
                                        if (pharmacy != null)
                                        {

                                            var apothecary = new Apothecary
                                            {
                                                Name = name,
                                                Surname = surname,
                                                Age = apothecaryAge,
                                                Experience = experiencee,
                                                Pharmacy = pharmacy,

                                            };
                                            pharmacy.Apothecaries.Add(apothecary);
                                            _apothecaryRepository.Create(apothecary);
                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"ID:{apothecary.ID},Name;{apothecary.Name},Surname:{apothecary.Surname},Age:{apothecary.Age},Experience:{apothecary.Experience}");
                                        }
                                        else
                                        {

                                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no pharmmacy name like that please enter right name ");
                                            goto PharmacyList;
                                        }
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Age mustn't be smaller than 18 ");
                                        goto Experience;
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
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter id in digits");
                    goto Digits;
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no pharmacy please create it");
            }
        }
        public void UpdateApothecary()
        {
            GetAll();
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
                            if (newexperience > 0 && newexperience < newage && newexperience < 18)
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
        public void DeleteApothecary()
        {
            GetAll();
        ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter the ID of the apothecary you want to delete ");
            string ID = Console.ReadLine();
            int Id;

            bool result = int.TryParse(ID, out Id);

            var apothecary = _apothecaryRepository.Get(a => a.ID == Id);

            if (apothecary != null)
            {
                _apothecaryRepository.Delete(apothecary);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Apothecary with ID:{apothecary.ID} is deleted");
            }
            else

            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Apothecary with this ID  doesn't exist");
                goto ID;
            }


        }
        public void GetAll()
        {
            var apothecaries = _apothecaryRepository.GetAll();

            if (apothecaries.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "All apothecary's list");

                foreach (var apothecary in apothecaries)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id - {apothecary.ID}, Fullname - {apothecary.Name} {apothecary.Surname},Age :{apothecary.Age},Experience:{apothecary.Experience}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no apothecary,please create it ");
            }
        }
        public void GetAllApothecaryByPharmacy()
        {
            var pharmacies = _pharmacyRepository.GetAll();
            if (pharmacies.Count > 0)
            {
            All: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Pharmacy's list");
                foreach (var pharmacy in pharmacies)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, $"ID:{pharmacy.ID},Name:{pharmacy.Name},Address:{pharmacy.Address},ContactNumber:{pharmacy.ContactNumber}");
                }

            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please enter pharmacy's id to print its apothecaries");
                string pharmacyid = Console.ReadLine();
                int Id;
                bool result = int.TryParse(pharmacyid, out Id);
                if (result)
                {
                    var pharmacy = _pharmacyRepository.Get(p => p.ID == Id);
                    if (pharmacy != null)
                    {
                        var apothecaries = _apothecaryRepository.GetAll(a => a.Pharmacy.ID == Id);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, $"All apothecaries whom are working  in Pharmacy: {pharmacy.Name} Address: {pharmacy.Address} ContactNumber:{pharmacy.ContactNumber}");
                        foreach (var apothecary in apothecaries)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkGray, $"Apothecary's ID:{apothecary.ID},Name:{apothecary.Name},Surname:{apothecary.Surname},Age:{apothecary.Age},Experience:{apothecary.Experience}");
                        }

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no apothecary like that");
                        goto All;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter number");
                    goto ID;
                }

            }


        }

    }

}









