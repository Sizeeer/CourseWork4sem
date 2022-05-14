using TrackerLibrary.DAL;
using TrackerLibrary.DTO;

namespace TrackerLibrary.BLL
{
	public class TournamentViewerFormHandling
	{
		public void UpdateMatchupModel(MatchupModel m)
		{
			GlobalConfig.Connection.UpdateMatchup(m);
		}

		public void CompleteTournament(TournamentModel m)
		{
			GlobalConfig.Connection.CompleteTournament(m);
		}
	}
}
