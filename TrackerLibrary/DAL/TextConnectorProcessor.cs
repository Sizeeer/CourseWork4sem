using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using TrackerLibrary.DTO;

// Load the textFile (done)
// Convert the text to List<prizeModel> (done)
// Find the ID
// Add the new record with the new ID
// Convert the prizes to list<string>
// Save the list<string> to the text files

namespace TrackerLibrary.DAL
{
	// The reason why I make this seperate class is just to use static major
	public static class TextConnectorProcessor
	{
		// Extention method
		public static string FullFilePath(this string fileName)
		{
			// Use " \\ " in c# to recognized the path : 
			// C:\TournamentMangagement\TextFile.csv
			return $"{ConfigurationManager.AppSettings["filePath"] }\\{fileName}";
		}

		// A list of string is represent the full line of text file
		public static List<string>LoadFile(this string file)
		{
			if(!File.Exists(file))
			{
				return new List<string>();
			}
			return File.ReadAllLines(file).ToList();
		}

		public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
		{
			List<PrizeModel> output = new List<PrizeModel>();

			foreach(string line in lines)
			{
				string [] cols = line.Split(',');
				PrizeModel p = new PrizeModel();
				p.Id = int.Parse(cols[0]);
				p.PlaceNumber = int.Parse(cols[1]);
				p.PlaceName = cols[2];
				p.PrizeAmount = decimal.Parse(cols[3]);
				p.PrizePercentage = float.Parse(cols[4]);
				output.Add(p);
			}
			return output;
			
		}

		public static List<PersonModel> ConvertToPeopleModels(this List<string> lines)
		{
			List<PersonModel> output = new List<PersonModel>();

			foreach (string line in lines)
			{
				string[] cols = line.Split(',');
				PersonModel p = new PersonModel();
				p.Id = int.Parse(cols[0]);
				p.FirstName = cols[1];
				p.LastName = cols[2];
				p.EmailAddress = cols[3];
				p.CellPhoneNumber = cols[4];
				output.Add(p);
			}
			return output;

		}

		public static List<TeamModel> ConvertToTeamModels(this List<string> lines)
		{
			// id, team name, lists of id seperated by the pipe
			// 3, Tim's Team, 1|2|3|
			List<TeamModel> output = new List<TeamModel>();
			List<PersonModel> people = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPeopleModels();

			foreach (string line in lines)
			{
				string[] cols = line.Split(',');
				TeamModel t = new TeamModel();
				t.Id = int.Parse(cols[0]);
				t.TeamName = cols[1];

				string[] personId = cols[2].Split('|');
				foreach(string id in personId)
				{
					t.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());
				}
				output.Add(t);
			}
			return output;

		}

		public static List<TournamentModel>ConvertToTournamentModels(this List<string>lines)
		{
			// id = 0
			// Tourament = 1
			// EntryFee = 2
			// Entered Team = 3
			// Prizes = 4
			// Rounds = 5

			// id, TournamentName, EntryFee, (id|id|id - EnteredTeams), (id|id|id - Prizes), (Rounds id^id^id)
			List<TournamentModel> output = new List<TournamentModel>();
			List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();
			List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();
			foreach(string line in lines)
			{
				string[] cols = line.Split(',');
				TournamentModel tm = new TournamentModel();
				tm.Id = int.Parse(cols[0]);
				tm.TournamentName = cols[1];
				tm.EntryFee = float.Parse(cols[2]);
				string[] teamIds = cols[3].Split('|');
				foreach(string id in teamIds)
				{
					//t.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());
					tm.EnteredTeams.Add(teams.Where(x => x.Id == int.Parse(id)).First());
			
				}
				string []prizeIds = cols[4].Split('|');
				foreach (string id in prizeIds)
				{
					//t.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());
					tm.Prizes.Add(prizes.Where(x => x.Id == int.Parse(id)).First());
				
				}
				output.Add(tm);
			}
			return output;
			// TODO - capture round information
		}



		public static void SaveToPrizesFile(this List<PrizeModel>models)
		{
			List<string> lines = new List<string>();

			foreach(PrizeModel p in models)
			{
				lines.Add($"{p.Id},{p.PlaceNumber}, {p.PlaceName}, {p.PrizeAmount},{p.PrizePercentage}");
			}
			File.WriteAllLines(GlobalConfig.PrizesFile.FullFilePath(), lines);
		}

		

		public static void SaveToPeopleFile(this List<PersonModel> models)
		{
			List<string> lines = new List<string>();

			foreach (PersonModel p in models)
			{
				lines.Add($"{p.Id},{p.FirstName}, {p.LastName}, {p.EmailAddress},{p.CellPhoneNumber}");
			}
			File.WriteAllLines(GlobalConfig.PeopleFile.FullFilePath(), lines);
		}

		public static void SaveToTeamFile(this List<TeamModel> models)
		{
			List<string> lines = new List<string>();

			foreach (TeamModel t in models)
			{
				lines.Add($"{t.Id},{t.TeamName}, {ConvertPeopleListToString(t.TeamMembers)}");
			}
			File.WriteAllLines(GlobalConfig.TeamFile.FullFilePath(), lines);
		}

		public static void SaveToTournamentFile(this List<TournamentModel> models)
		{
			// id = 0
			// Tourament = 1
			// EntryFee = 2
			// Entered Team = 3
			// Prizes = 4
			// Rounds = 5

			// id, TournamentName, EntryFee, (id|id|id - EnteredTeams), (id|id|id - Prizes), (Rounds id^id^id)
			List<string> lines = new List<string>();

			foreach (TournamentModel tm in models)
			{
				lines.Add($"{tm.Id},{tm.TournamentName}, {tm.EntryFee}, {ConvertTeamListToString(tm.EnteredTeams)}, " +
					$"{ConvertPrizeListToString(tm.Prizes)}, {ConvertRoundListToString(tm.Rounds)}");
			}
			File.WriteAllLines(GlobalConfig.TournamentFile.FullFilePath(), lines);
		}

		public static void SaveRoundsToFile(this TournamentModel models, string matchupFile, string matchupEntryFile)
		{
			// Loop through each round
			// Loop through each matchup
			// Get the ID for the new matchup and save the record 
			// Loop through each entry, get the ID and save it

			foreach (List<MatchupModel> round in models.Rounds)
			{
				foreach (MatchupModel matchup in round)
				{
					// Loop all of the matchups from file 
					// Get the top id and add one
					// store the id
					// save the matchup record 
					matchup.SaveMatchupToFile(matchupFile ,matchupEntryFile);

					foreach (MatchupEntryModel entry in matchup.Entries)
					{
						
					}
				}
			}
		}

		private static void SaveMatchupToFile(this MatchupModel matchup, string matchupFile, string matchupEntryFile)
		{
			foreach (MatchupEntryModel entry in matchup.Entries)
			{
				/*entry.SaveEntryToFile(matchupFile, entryFile);*/
			}
		}

		private static void SaveEntryToFile(this MatchupModel matchup, string matchupEntryFile)
		{

		}

		private static string ConvertPeopleListToString(List<PersonModel>people)
		{
			string output = "";

			// prevent the crash of output lenght	
			if(people.Count == 0)
			{
				return "";
			}

			// 2|5
			foreach(PersonModel p in people)
			{
				output += $"{p.Id}|";
			}

			output = output.Substring(0, output.Length - 1);
			return output;
		}

		private static string ConvertTeamListToString(List<TeamModel> teams)
		{
			string output = "";

			// prevent the crash of output lenght	
			if (teams.Count == 0)
			{
				return "";
			}

			// 2|5
			foreach (TeamModel t in teams)
			{
				output += $"{t.Id}|";
			}

			output = output.Substring(0, output.Length - 1);
			return output;
		}

		private static string ConvertPrizeListToString(List<PrizeModel> prizes)
		{
			string output = "";

			// prevent the crash of output lenght	
			if (prizes.Count == 0)
			{
				return "";
			}

			// 2|5
			foreach (PrizeModel p in prizes)
			{
				output += $"{p.Id}|";
			}

			output = output.Substring(0, output.Length - 1);
			return output;
		}

		private static string ConvertRoundListToString(List<List<MatchupModel>> rounds)
		{
			string output = "";

			// prevent the crash of output lenght	
			if (rounds.Count == 0)
			{
				return "";
			}

			// 2|5
			foreach (List<MatchupModel> r in rounds)
			{
				output += $"{ConvertMatchupListToString(r)}|";
			}

			output = output.Substring(0, output.Length - 1);
			return output;
		}

		private static string ConvertMatchupListToString(List<MatchupModel> matchups)
		{
			string output = "";

			// prevent the crash of output lenght	
			if (matchups.Count == 0)
			{
				return "";
			}

			// 2|5
			foreach (MatchupModel m in matchups)
			{
				output += $"{m.Id}|";
			}

			output = output.Substring(0, output.Length - 1);
			return output;
		}
		
		private static TeamModel LookupTeamById(int id)
		{
			List<string> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile();

			foreach (string team in teams)
			{
				string[] cols = team.Split(',');

				if (cols[0] == id.ToString())
				{
					List<string> matchingTeams = new List<string>();
					matchingTeams.Add(team);
					return matchingTeams.ConvertToTeamModels().First();
				}
			}

			return null;
		}
		
		private static MatchupModel LookupMatchupById(int id)
		{
			List<string> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile();

			foreach (string matchup in matchups)
			{
				string[] cols = matchup.Split(',');

				if (cols[0] == id.ToString())
				{
					List<string> matchingMatchups = new List<string>();
					matchingMatchups.Add(matchup);
					return matchingMatchups.ConvertToMatchupModels().First();
				}
			}

			return null;
		}
		
		public static List<MatchupEntryModel> ConvertToMatchupEntryModels(this List<string> lines)
		{
			// Id = 0, TeamCompeting = 1, Score = 2, ParentMatchup = 3
			List<MatchupEntryModel> output = new List<MatchupEntryModel>();

			foreach (string line in lines)
			{
				string[] cols = line.Split(',');

				MatchupEntryModel me = new MatchupEntryModel();

				me.Id = int.Parse(cols[0]);
				
				if (cols[1].Length == 0)
				{
					me.TeamCompeting = null;
				}
				else
				{
					me.TeamCompeting = LookupTeamById(int.Parse(cols[1]));
				}
				
				me.Score = double.Parse(cols[2]);

				int parentId = 0;
				if (int.TryParse(cols[3], out parentId))
				{
					me.ParentMatchup = LookupMatchupById(parentId);
				}
				else 
				{
					me.ParentMatchup = null;
				}

				output.Add(me);
			}

			return output;
		}
		
		private static string ConvertMatchupEntryListToString(List<MatchupEntryModel> entries)
		{
			string output = string.Empty;

			if (entries.Count == 0)
			{
				return "";
			}

			foreach (MatchupEntryModel e in entries)
			{
				output += $"{ e.Id }|";
			}

			output = output.Substring(0, output.Length - 1);

			return output.Trim('|');
		}
		
		private static List<MatchupEntryModel> ConvertStingToMatchupEntryModels(string input)
		{
			string[] ids = input.Split('|');
			List<MatchupEntryModel> output = new List<MatchupEntryModel>();
			List<string> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile();
			List<string> matchingEntries = new List<string>();

			foreach (string id in ids)
			{
				foreach (string entry in entries)
				{
					string[] cols = entry.Split(',');

					if (cols[0] == id)
					{
						matchingEntries.Add(entry);
					}
				}
			}

			output = matchingEntries.ConvertToMatchupEntryModels();

			return output;
		}
		
		public static List<MatchupModel> ConvertToMatchupModels(this List<string> lines)
		{
			// Id = 0, Entries = 1(pipe delimited by Id), Winner = 2, MatchupRound = 3
			List<MatchupModel> output = new List<MatchupModel>();

			foreach (string line in lines)
			{
				string[] cols = line.Split(',');

				MatchupModel m = new MatchupModel();

				m.Id = int.Parse(cols[0]); ;
				m.Entries = ConvertStingToMatchupEntryModels(cols[1]);

				if (cols[2].Length == 0)
				{
					m.Winner = null;
				}
				else
				{ 
					m.Winner = LookupTeamById(int.Parse(cols[2]));
				}

				m.MatchupRound = int.Parse(cols[3]);

				output.Add(m);
			}

			return output;
		}
		
		public static void UpdateEntryToFile(this MatchupEntryModel entry)
		{
			List<MatchupEntryModel> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();
			MatchupEntryModel oldEntry = new MatchupEntryModel();

			foreach (MatchupEntryModel e in entries)
			{
				if (e.Id == entry.Id)
				{
					oldEntry = e;
				}
			}

			entries.Remove(oldEntry);

			entries.Add(entry);

			List<string> lines = new List<string>();

			foreach (MatchupEntryModel e in entries)
			{
				string parent = "";
				if (e.ParentMatchup != null)
				{
					parent = e.ParentMatchup.Id.ToString();
				}

				string teamCompeting = "";
				if (e.TeamCompeting != null)
				{
					teamCompeting = e.TeamCompeting.Id.ToString();
				}

				lines.Add($"{ e.Id },{ teamCompeting },{ e.Score },{ parent }");
			}

			File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);
		}
		
		public static void UpdateMatchupToFile(this MatchupModel matchup)
		{
			List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

			MatchupModel oldMatchup = new MatchupModel();

			foreach (MatchupModel m in matchups)
			{
				if (m.Id == matchup.Id)
				{
					oldMatchup = m;
				}
			}

			matchups.Remove(oldMatchup);

			matchups.Add(matchup);

			foreach (MatchupEntryModel entry in matchup.Entries)
			{
				entry.UpdateEntryToFile();
			}

			List<string> lines = new List<string>();

			foreach (MatchupModel m in matchups)
			{
				string winner = "";
				if (m.Winner != null)
				{
					winner = m.Winner.Id.ToString();
				}
				lines.Add($"{ m.Id },{ ConvertMatchupEntryListToString(m.Entries) },{ winner },{ m.MatchupRound }");
			}

			File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
		}
	}
}
