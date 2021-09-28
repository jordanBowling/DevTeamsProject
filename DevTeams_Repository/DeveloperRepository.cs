using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class DeveloperRepository
    {
        //Field
        public List<Developer> _developerDirectory = new List<Developer>();

        //Create
        public void AddDeveloperToDirectory(Developer developer)
        {
          

            _developerDirectory.Add(developer);

         
        }
        
        //Read
        public List<Developer> GetDevelopers()
        {
            return _developerDirectory;
        }

        public Developer GetDeveloperByID(int developerID)
        {
            foreach (Developer developer in _developerDirectory)
            {
                if (developer.IDNumber == developerID)
                {
                    return developer;
                }
            }
            return null;
        }

        //Update
        public bool UpdateDeveloperDirectory(Developer oldDevInfo, Developer newDevInfo)
        {
            if (oldDevInfo != null)
            {
                oldDevInfo.FirstName = newDevInfo.FirstName;
                oldDevInfo.LastName = newDevInfo.LastName;
                oldDevInfo.IDNumber = newDevInfo.IDNumber;
                oldDevInfo.PluralSightAccess = newDevInfo.PluralSightAccess;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public void RemoveDeveloperFromDirectoryByID(Developer developer )
        {
            _developerDirectory.Remove(developer);
            
        }
    }
}
