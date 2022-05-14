using System.Collections.Generic;
using TrackerLibrary.DAL;
using TrackerLibrary.DTO;

namespace TrackerLibrary.BLL
{
	public class CreateTournamentFormHandling
	{
		public List<TeamModel> Get_All_Teams()
		{
			List<TeamModel> t = GlobalConfig.Connection.Get_All_Teams();
			return t;
		}
		public void CreateTournament(TournamentModel model)
		{	
			GlobalConfig.Connection.CreateTournament(model);
		}
	}
}
