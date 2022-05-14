using System.Collections.Generic;
using System.Linq;
using TrackerLibrary.BUL;
using TrackerLibrary.DTO;

namespace TrackerLibrary.DAL
{
	public class TextConnector : IDataConnection
	{
		
		public PersonModel CreatePeople(PersonModel model)
		{
			List<PersonModel> People = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPeopleModels();

			int currentId = 1;

			if(People.Count > 0)
			{
				currentId = People.OrderByDescending(x => x.Id).First().Id + 1;
			}

			model.Id = currentId;
			People.Add(model);
			People.SaveToPeopleFile();
			return model;
		}

		// TODO - Wire Up the connection for text files
		public PrizeModel CreatePrize(PrizeModel model)
		{	
			// Load the textFile
			// Convert the text to List<prizeModel>
			List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

			// Find the ID
			int currentId = 1;

			// if text file does have a prizes --> find the max ID
			if(prizes.Count > 0)
			{
				// currentID  = 0 + 1
				currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
			}

			// Add the new record with the new ID
			model.Id = currentId;

			prizes.Add(model);

			// Convert the prizes to list<string>
			// Save the list<string> to the text files
			prizes.SaveToPrizesFile();
			return model;

		}

		public TeamModel CreateTeam(TeamModel model)
		{
			List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();

			// Find the ID
			int currentId = 1;

			// if text file does have a prizes --> find the max ID
			if (teams.Count > 0)
			{
				// currentID  = 0 + 1
				currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
			}

			// Add the new record with the new ID
			model.Id = currentId;

			teams.Add(model);

			// Convert the prizes to list<string>
			// Save the list<string> to the text files
			teams.SaveToTeamFile();

			return model;
		}

		
		public List<PersonModel> Get_All_Persons()
		{
			List<PersonModel> person = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPeopleModels();
			return person;
		}

		public List<TeamModel> Get_All_Teams()
		{
			List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();
			return teams;
		}

		public void CreateTournament(TournamentModel model)
		{
			List<TournamentModel> tournaments = GlobalConfig.TournamentFile.FullFilePath().LoadFile()
				.ConvertToTournamentModels();
			int currentId = 1;

			// if text file does have a prizes --> find the max ID
			if (tournaments.Count > 0)
			{
				// currentID  = 0 + 1
				currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
			}
			model.Id = currentId;

			/*tournaments.SaveRoundsToFile(model, MatchupFile, MatchupEntryFile);*/
			tournaments.SaveToTournamentFile();

			tournaments.Add(model);

		}

		public List<TournamentModel> Get_All_Tournaments()
		{
			return GlobalConfig.TournamentFile
				.FullFilePath()
				.LoadFile()
				.ConvertToTournamentModels();
		}

		public void UpdateMatchup(MatchupModel model)
		{
			model.UpdateMatchupToFile();
		}

		public void CompleteTournament(TournamentModel model)
		{
			List<TournamentModel> tournaments = GlobalConfig.TournamentFile
				.FullFilePath()
				.LoadFile()
				.ConvertToTournamentModels();

			tournaments.Remove(model);

			tournaments.SaveToTournamentFile();
			TournamentLogic.UpdateTournamentResults(model);
		}
	}
}
