using System.Collections.Generic;

namespace TrackerLibrary.DTO
{
	public class MatchupModel
	{
		/// <summary>
		/// The set of teams that were involved in this match
		/// </summary>
		public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();

		/// <summary>
		/// The ID from database that will be used to look up the winner
		/// </summary>
		public int WinnerID { get; set; }

		/// <summary>
		/// The winner of the match
		/// </summary>
		public TeamModel Winner { get; set; }

		/// <summary>
		/// which round this match is a part of 
		/// </summary>
		public int MatchupRound { get; set; }

		/// <summary>
		/// the unique identifier for the matchup
		/// </summary>
		public int Id { get; set; }

		public string DisplayName
		{
			get
			{
				string output = "";
				foreach(MatchupEntryModel me in Entries)
				{
					if(me.TeamCompeting != null)
					{
						if (output.Length == 0)
						{
							output = me.TeamCompeting.TeamName;
						}
						else
						{
							output += $" vs. {me.TeamCompeting.TeamName}";
						}
					}
					else
					{
						output = "Matchup not yet determined";
						break;
					}
					
				}
				return output;	
			}
		}
	}
}
