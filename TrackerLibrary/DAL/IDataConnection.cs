using System.Collections.Generic;
using TrackerLibrary.DTO;

namespace TrackerLibrary.DAL
{
	public interface IDataConnection
	{
		PrizeModel CreatePrize(PrizeModel model);
		PersonModel CreatePeople(PersonModel model);
		TeamModel CreateTeam(TeamModel model);
		void CreateTournament(TournamentModel model);

		void CompleteTournament(TournamentModel model);
		void DeleteTournament(TournamentModel model);
		void UpdateMatchup(MatchupModel model);
		List<TeamModel> Get_All_Teams();
		List<PersonModel> Get_All_Persons();

		List<TeamRate> Get_Teams_Rates();
		List<TournamentModel> Get_All_Tournaments();
	}
}
