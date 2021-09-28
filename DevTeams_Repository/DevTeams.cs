using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class DevTeams
    {
        public DevTeams() { }
        public DevTeams(string devTeamName, int devTeamID, List<Developer> teamMembers)
        {
            DevTeamName = devTeamName;
            DevTeamID = devTeamID;
            TeamMembers = teamMembers;
        }
        
        public string DevTeamName { get; set; }
        public int DevTeamID { get; set; }
        public List<Developer> TeamMembers = new List<Developer>();


    }
}
