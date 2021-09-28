using DevTeams_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevTeams_Console
{
    class ProgramUI
    {
        private DeveloperRepository _repo = new DeveloperRepository();

        private DevTeamsRepository _teamRepo = new DevTeamsRepository();

        public void Run()
        {
            SeedData();
            Menu();
        }

        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Komodo Insurance Developer Portal\n\n");

                Console.WriteLine($"Menu:\n\n" +
                    $"1. Add New Developer \n" +
                    $"2. Delete Developer \n" +
                    $"3. Update Existing Developer \n" +
                    $"4. View All Developers \n" +
                    $"5. View Specific Developer \n" +
                    $"6. Add New Dev Team \n" +
                    $"7. Update Existing Dev Team \n" +
                    $"8. View Dev Teams \n" +
                    $"9. View Specific Dev Team \n" +
                    $"10. Add Developer To Team \n" +
                    $"11. Remove Developer From Team \n" +
                    $"12. Exit \n");

                Console.WriteLine("Please input the number of the menu item you would like to select: \n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddNewDeveloper();
                        break;
                    case "2":
                        DeleteDeveloper();
                        break;
                    case "3":
                        UpdateExistingDeveloper();
                        break;
                    case "4":
                        ShowAllDevelopers();
                        break;
                    case "5":
                        GetDeveloperByID();
                        break;
                    case "6":
                        AddNewDevTeam();
                        break;
                    case "7":
                        break;
                    case "8":
                        ViewDevTeams();
                        break;
                    case "9":
                        break;
                    case "10":
                        break;
                    case "11":
                        break;
                    case "12":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number 1 - 12");
                        break;
                }

                Console.Clear();

            }
        }

        private void AddNewDeveloper()
        {
            Console.Clear();
            Developer developer = new Developer();
            //First Name
            Console.WriteLine("First Name: ");
            developer.FirstName = Console.ReadLine();

            //Last Name
            Console.WriteLine("Last Name: ");
            developer.LastName = Console.ReadLine();

            //ID
            Console.WriteLine("Developer ID Number: ");
            developer.IDNumber = Convert.ToInt32(Console.ReadLine());

            //PluralSight
            Console.WriteLine("Does this employee have access to PluralSight? \n" +
                "(Y/N)");

            string userInput = Console.ReadLine().ToLower();

            if (userInput == "y")
            {
                developer.PluralSightAccess = true;
            }
            else
            {
                developer.PluralSightAccess = false;
            }
            
            

            DeveloperRepository repo = new DeveloperRepository();
            repo.AddDeveloperToDirectory(developer);

        }

        private void DeleteDeveloper()
        {
            Console.Clear();
            List<Developer> listOfDevs = _repo.GetDevelopers();
            int index = 1;
            foreach (Developer developer in listOfDevs)
            {
                Console.WriteLine($"\n\n{index}. {developer.IDNumber}- {developer.FullName}\n\n");
                index++;
            }

            Console.WriteLine("Please enter the ID Number of the employee you would like to delete.\n");
            
            int userInput = Convert.ToInt32(Console.ReadLine());
            
            foreach (Developer developers in listOfDevs)
            {
                if (userInput == developers.IDNumber)
                {
                    _repo.RemoveDeveloperFromDirectoryByID(developers);
                }
            }
            
            PressAnyKeyToContinue(); 
        }

        private void UpdateExistingDeveloper()
        {
            Console.Clear();

            Console.WriteLine("What is the ID Number of the developer you would like to edit?\n");
            int targetDevID = Convert.ToInt32(Console.ReadLine());

            Developer targetDev = _repo.GetDeveloperByID(targetDevID);

            if (targetDev == null)
            {
                Console.WriteLine("We can not find that developer.");
                PressAnyKeyToContinue();
                return;
            }

            Developer updatedDev = new Developer();

            Console.WriteLine($"\nOriginal First Name: {targetDev.FirstName}\n" +
                $"Please enter a new First Name: \n");
            updatedDev.FirstName = Console.ReadLine();
            
            Console.WriteLine($"\nOriginal Last Name: {targetDev.LastName}\n" +
                $"Please enter a new Last Name: \n");
            updatedDev.LastName = Console.ReadLine();

            Console.WriteLine($"\nOriginal ID Number: {targetDev.IDNumber}\n" +
                $"Please enter a new ID Number: \n");
            updatedDev.IDNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nOriginal PluralSight Status: {targetDev.PluralSightAccess}\n" +
                $"Please enter a new PluralSight Status (Y/N) \n");
            string pluralSight = Console.ReadLine().ToLower();
            bool pluralSightBool;
            if (pluralSight == "y")
            {
                pluralSightBool = true;
            }
            else
            {
                pluralSightBool = false;
            }
            updatedDev.PluralSightAccess = pluralSightBool;

            _repo.UpdateDeveloperDirectory(targetDev, updatedDev);
        }

        private void ShowAllDevelopers()
        {
            Console.Clear();
            List<Developer> listOfDevelopers = _repo.GetDevelopers();
            foreach (Developer developers in listOfDevelopers)
            {
                DisplayContent(developers);
            }

            PressAnyKeyToContinue();
        }

        private void GetDeveloperByID()
        {
            Console.Clear();
            Console.WriteLine("Please enter the ID number of the employee you are looking for: \n");
            int userInput = Convert.ToInt32(Console.ReadLine());
            
            List<Developer> listOfDevelopers = _repo.GetDevelopers();
            foreach (Developer developer in listOfDevelopers)
            {
                if (userInput == developer.IDNumber)
                {
                    DisplayContent(developer);
                }
            }

            PressAnyKeyToContinue();
        }

        private void AddNewDevTeam()
        {
            Console.Clear();

            DevTeams devTeam = new DevTeams();

            Console.WriteLine("What is the name of your new Dev Team?\n");
            devTeam.DevTeamName = Console.ReadLine();

            Console.WriteLine("What is the Dev Team ID of your new Dev Team\n");
            devTeam.DevTeamID = Convert.ToInt32(Console.ReadLine());

            List<Developer> listOfDevelopers = _repo.GetDevelopers();
            foreach (Developer developers in listOfDevelopers)
            {
                DisplayContent(developers);
            }


            PressAnyKeyToContinue();
        }

        private void ViewDevTeams()
        {
            Console.Clear();

            List<DevTeams> devTeams = _teamRepo.GetDevTeamsList();
            foreach (DevTeams devTeam in devTeams)
            {
                Console.WriteLine($"Team Name: {devTeam.DevTeamName}\n" +
                    $"Dev Team ID: {devTeam.DevTeamID}\n" +
                    $"Team Members: {devTeam.TeamMembers}");
            }

            PressAnyKeyToContinue();
        }


        //Helper
        private void DisplayContent(Developer developers)
        {
            Console.WriteLine($"\n" +
                $"Name: {developers.FullName}\n" +
                $"ID Number: {developers.IDNumber}\n" +
                $"PluralSight Access? {developers.PluralSightAccess}\n\n");
        }

        private void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
        }

        //Seed Data
        private void SeedData()
        {
            Developer jBowling = new Developer("Bowling", "Jordan", 013, true);
            Developer sRogan = new Developer("Rogan", "Seth", 014, true);
            Developer pRudd = new Developer("Rudd", "Paul", 015, false);
            Developer tCurry = new Developer("Curry", "Tim", 016, false);

            _repo.AddDeveloperToDirectory(jBowling);
            _repo.AddDeveloperToDirectory(sRogan);
            _repo.AddDeveloperToDirectory(pRudd);
            _repo.AddDeveloperToDirectory(tCurry);



            
            
        }
    }
}
