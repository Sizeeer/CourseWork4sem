using TrackerLibrary.DAL;
using TrackerLibrary.DTO;

namespace TrackerLibrary.BUL
{
	public class TournamentViewerFormHandling
	{
		// Update a matchup (Score, winner, parent matchup)
		public void UpdateMatchupModel(MatchupModel m)
		{
			GlobalConfig.Connection.UpdateMatchup(m);
		}
	}
}
