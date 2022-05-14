using System.Collections.Generic;
using TrackerLibrary.DAL;
using TrackerLibrary.DTO;

namespace TrackerLibrary.BUL
{
	public class CreateTournamentFormHandling
	{
		// Get all teams from sql;
		public List<TeamModel> Get_All_Teams()
		{
			List<TeamModel> t = GlobalConfig.Connection.Get_All_Teams();
			return t;
		}

		// Insert a tournament into db
		public void CreateTournament(TournamentModel model)
		{	
			GlobalConfig.Connection.CreateTournament(model);
		}
	}
}
