using System.Collections.Generic;
using TrackerLibrary.DAL;
using TrackerLibrary.DTO;

namespace TrackerLibrary.BUL
{
	public class TournamentDashboardFormHandling
	{
		// Get all tournaments from db
		public List<TournamentModel> Get_All_Tournaments()
		{
			List<TournamentModel> T = GlobalConfig.Connection.Get_All_Tournaments();
			return T;
		}
	}
}
