using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    public class DevTeamsRepository
    {
        public List<DevTeams> _devTeamList = new List<DevTeams>();

        //Create
        public void AddDevTeamToList(DevTeams devTeam)
        {
            _devTeamList.Add(devTeam);
        }

        //Read
        public List<DevTeams> GetDevTeamsList()
        {
            return _devTeamList;
        }

        //Update
        public void UpdateDevTeamsList(DevTeams oldDevTeamInfo, DevTeams newDevTeamsInfo)
        {
            if (oldDevTeamInfo != null)
            {
                oldDevTeamInfo.DevTeamName = newDevTeamsInfo.DevTeamName;
                oldDevTeamInfo.DevTeamID = newDevTeamsInfo.DevTeamID;
                //oldDevTeamInfo.TeamMembers = newDevTeamsInfo.TeamMembers;
            }
        }

        //Delete

    }
}
