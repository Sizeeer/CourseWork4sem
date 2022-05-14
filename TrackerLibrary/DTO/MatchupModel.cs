using System.Collections.Generic;

namespace TrackerLibrary.DTO
{
	public class MatchupModel
	{
		public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
		public int WinnerID { get; set; }
		public TeamModel Winner { get; set; }
		public int MatchupRound { get; set; }
		public int Id { get; set; }
		
		public string DisplayName
		{
			get
			{
				string output = "";
				foreach (MatchupEntryModel me in Entries)
				{
					if (me.TeamCompeting != null)
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
						output = "Состязание не доступно";
						break;
					}
				}
				return output;
			}
		}
	}
}
