using System.Collections.Generic;
using TrackerLibrary.DAL;
using TrackerLibrary.DTO;

namespace TrackerLibrary.BLL
{
	public class TournamentDashboardFormHandling
	{
		public List<TournamentModel> Get_All_Tournaments()
		{
			List<TournamentModel> T = GlobalConfig.Connection.Get_All_Tournaments();
			return T;
		}
		
		public void DeleteTournament(TournamentModel model)
		{
			GlobalConfig.Connection.DeleteTournament(model);
		}
	}
}
