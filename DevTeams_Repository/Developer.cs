using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class Developer
    {
        public Developer() { }

        public Developer(string lastName, string firstName, int idNumber, bool pluralSightAccess)
        {
            LastName = lastName;
            FirstName = firstName;
            IDNumber = idNumber;
            PluralSightAccess = pluralSightAccess;

        }
        
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string FullName
        {
            get
            {
                string fullName = LastName + ", " + FirstName;
                return fullName;
            }
        }

        public int IDNumber { get; set;  }

        public bool PluralSightAccess { get; set; }

        public string TeamAssignment { get; set; }
    }
}
