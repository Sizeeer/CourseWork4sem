using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DAL;
using TrackerLibrary.DTO;

namespace TrackerLibrary.BLL
{
    public class RateHandling
    {
        public List<TeamRate> GetTeamsRates()
        {
            List<TeamRate> teamsRates = GlobalConfig.Connection.Get_Teams_Rates();

            return teamsRates;
        }
    }
}
