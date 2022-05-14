using System.Collections.Generic;
using System.Linq;
using TrackerLibrary.BLL;
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
		public PrizeModel CreatePrize(PrizeModel model)
		{	
			List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

			int currentId = 1;

			if(prizes.Count > 0)
			{
				currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
			}

			model.Id = currentId;

			prizes.Add(model);

			prizes.SaveToPrizesFile();
			return model;
		}
		public TeamModel CreateTeam(TeamModel model)
		{
			List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();

			int currentId = 1;

			if (teams.Count > 0)
			{
				currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
			}

			model.Id = currentId;

			teams.Add(model);

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

			if (tournaments.Count > 0)
			{
				currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
			}
			model.Id = currentId;

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
