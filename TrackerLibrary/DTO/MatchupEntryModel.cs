namespace TrackerLibrary.DTO
{
	public class MatchupEntryModel
	{
		public int Id { get; set; }
		public int TeamCompetingID { get; set; }
		/// <summary>
		/// Represents one team in the matchup
		/// </summary>
		public TeamModel TeamCompeting { get; set; }

		/// <summary>
		/// Repersents the score for this particular team
		/// </summary>
		public double Score { get; set; }

		public int ParentMatchupID { get; set; }

		/// <summary>
		/// Represents the matchup that this team came from 
		/// as the winner
		/// </summary>
		public MatchupModel ParentMatchup { get; set; }

		public MatchupEntryModel(double initialScore)
		{

		}

		public MatchupEntryModel() { }
	}
}
