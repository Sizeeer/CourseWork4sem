using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using TrackerLibrary.DTO;

/*
@placeNumber INT,
@placeName NVARCHAR(100),
@prizeAmount MONEY,
@prizePercentage FLOAT,
@id INT = 0 OUTPUT 
 */
namespace TrackerLibrary.DAL
{
	public class SqlConnector : IDataConnection
	{
		private const string db = "TournamentManagement";
		// TODO - Make the CreatePrize method save to the database
		/// <summary>
		/// Save a new prize to the database 
		/// </summary>
		/// <param name="model"> The prize information </param>
		/// <returns> the prize information </returns>
		public PrizeModel CreatePrize(PrizeModel model)
		{
			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
			{
				var p = new DynamicParameters();
				p.Add("@placeNumber", model.PlaceNumber);
				p.Add("@placeName", model.PlaceName);
				p.Add("@prizeAmount", model.PrizeAmount);
				p.Add("@prizePercentage", model.PrizePercentage);
				p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

				connection.Execute("insertPrizes", p, commandType: CommandType.StoredProcedure);
				model.Id = p.Get<int>("@id");

			}
			return model;
		}

		public PersonModel CreatePeople(PersonModel model)
		{
			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
			{
				// Creating dynamic paramters list using dapper
				var p = new DynamicParameters();
				p.Add("@firstName", model.FirstName);
				p.Add("@lastName", model.LastName);
				p.Add("@emailAddress", model.EmailAddress);
				p.Add("@phoneNumber", model.CellPhoneNumber);
				p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

				connection.Execute("insertPeople", p, commandType: CommandType.StoredProcedure);
				model.Id = p.Get<int>("@id");

			}
			return model;
		}

		

		public TeamModel CreateTeam(TeamModel model)
		{
			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
			{
				// Creating dynamic paramters list using dapper
				var p = new DynamicParameters();
				p.Add("@teamName", model.TeamName);	
				p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

				connection.Execute("PROC_insertTeams", p, commandType: CommandType.StoredProcedure);
				model.Id = p.Get<int>("@id");

				foreach (PersonModel person in model.TeamMembers)
				{
					// Overwrite P, not call a new p
					p = new DynamicParameters();
					p.Add("@teamID", model.Id);
					p.Add("@personID", person.Id);
					p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

					connection.Execute("PROC_insert_TeamMembers", p, commandType: CommandType.StoredProcedure);

				}

			}
			return model;
		}

		public void CreateTournament(TournamentModel model)
		{
			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
			{
				SaveTournaments(model, connection);
				SaveTournamentPrizes(model, connection);
				SaveTournamentEntries(model, connection);
				SaveTournamentRounds(model, connection);

				
			}
		}

		private void SaveTournaments(TournamentModel model, IDbConnection connection)
		{
			// Creating dynamic paramters list using dapper
			var p = new DynamicParameters();
			p.Add("@tournamentName", model.TournamentName);
			p.Add("@entryFee", model.EntryFee);
			p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

			connection.Execute("PROC_insertTournament", p, commandType: CommandType.StoredProcedure);
			model.Id = p.Get<int>("@id");
		}

		private void SaveTournamentPrizes(TournamentModel model, IDbConnection connection)
		{
			foreach (PrizeModel prize in model.Prizes)
			{
				var p = new DynamicParameters();
				p.Add("@tournamentID", model.Id);
				p.Add("@prizeID", prize.Id);
				p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

				connection.Execute("PROC_insert_TournamentPrizes", p, commandType: CommandType.StoredProcedure);
			}
			
		}
		private void SaveTournamentEntries(TournamentModel model, IDbConnection connection)
		{
			foreach (TeamModel t in model.EnteredTeams)
			{
				// Overwrite P, not call a new p
				var p = new DynamicParameters();
				p.Add("@tournamentID", model.Id);
				p.Add("@teamID", t.Id);
				p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

				connection.Execute("PROC_insert_TournamentEntries", p, commandType: CommandType.StoredProcedure);

			}
		}

		private void SaveTournamentRounds(TournamentModel model, IDbConnection connection)
		{
			// List<List<MatchupModel>> Rounds
			// List<MatchupEntryModel> Entries

			// Loop through the rounds
			// Loop through the matchups
			// Save the matchup
			// Loop through the entries in the matchup and save them
			foreach (List<MatchupModel> round in model.Rounds)
			{
				foreach(MatchupModel matchup in round)
				{	
					var p = new DynamicParameters();
					p.Add("@tournamentID", model.Id);
					p.Add("@matchupRound", matchup.MatchupRound);
					p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

					connection.Execute("PROC_insertMatchups", p, commandType: CommandType.StoredProcedure);

					matchup.Id = p.Get<int>("@id");

					foreach (MatchupEntryModel entry in matchup.Entries)
					{
						p = new DynamicParameters();
						p.Add("@matchupID", matchup.Id);

						// The first round, entry.parentmatchup will be null
						if (entry.TeamCompeting == null)
						{
							p.Add("@teamCompetingID", null);
						}
						else
						{
							p.Add("@teamCompetingID", entry.TeamCompeting.Id);

						}

						if (entry.ParentMatchup == null)
						{
							p.Add("@parentMatchupID", null);
						}
						else
						{
							p.Add("@parentMatchupID", entry.ParentMatchup.Id);

						}
						
						p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

						connection.Execute("PROC_insertMatchupEntries", p, commandType: CommandType.StoredProcedure);

					}
				}
			}
		}

		public List<PersonModel> Get_All_Persons()
		{
			List<PersonModel> output = new List<PersonModel>();

			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
			{
				output = connection.Query<PersonModel>("selectPeople").ToList();
			}
			return output;
		}

		public List<TeamModel> Get_All_Teams()
		{
			List<TeamModel> output = new List<TeamModel>();

			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
			{
				output = connection.Query<TeamModel>("PROC_selectTeams").ToList();

				foreach (TeamModel team in output)
				{
					var p = new DynamicParameters();
					p.Add("@teamID", team.Id);
					team.TeamMembers = connection.Query<PersonModel>("PROC_selectTeamMembers_GetByTeam", p, commandType: CommandType.StoredProcedure).ToList();
				}		
			}

			
			return output;
		}

		public List<TournamentModel> Get_All_Tournaments()
		{
			List<TournamentModel> output = new List<TournamentModel>();

			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
			{
				output = connection.Query<TournamentModel>("PROC_selectTournaments").ToList();
				var p = new DynamicParameters();

				foreach (TournamentModel t in output)
				{
					p = new DynamicParameters();
					p.Add("@tournamentID", t.Id);
					// Populate prizes
					t.Prizes = connection.Query<PrizeModel>("PROC_selectPrizes_GetByTournament", p, commandType:CommandType.StoredProcedure).ToList();

					// Populate entered teams
					p = new DynamicParameters();
					p.Add("@tournamentID", t.Id);
					t.EnteredTeams = connection.Query<TeamModel>("PROC_selectTeams_GetByTournament", p, commandType: CommandType.StoredProcedure).ToList();

					foreach (TeamModel team in t.EnteredTeams)
					{
						p = new DynamicParameters();
						p.Add("@teamID", team.Id);
						team.TeamMembers = connection.Query<PersonModel>("PROC_selectTeamMembers_GetByTeam", p, commandType: CommandType.StoredProcedure).ToList();
					}

					// Popluate rounds
					p = new DynamicParameters();
					p.Add("@tournamentID", t.Id);
					List<MatchupModel> matchups = connection.Query<MatchupModel>("PROC_selectMatchups_GetByTournament", p, commandType: CommandType.StoredProcedure).ToList();

					foreach (MatchupModel matchup in matchups)
					{
						p = new DynamicParameters();
						p.Add("@matchupID", matchup.Id);
						matchup.Entries = connection.Query<MatchupEntryModel>("PROC_selectMatchupEntries_GetByMatchup", p, commandType: CommandType.StoredProcedure).ToList();

						// Populate each entry(2 models)
						// Popluate each matchup(1 model)
						List<TeamModel> allTeams = Get_All_Teams(); 

						// If we have a winner, insert to winner of the matchup that equals to ID in teamModel
						if(matchup.WinnerID > 0)
						{
							/*foreach(TeamModel t in allTeams)
							{
								if(matchup.WinnerID == t.Id)
								{
									matchup.Winner = t;
								}
							}*/
							matchup.Winner = allTeams.Where(x => x.Id == matchup.WinnerID).First();
						}

						foreach(var me in matchup.Entries)
						{
							// Check if we have and ID of teamcompeting
							if(me.TeamCompetingID > 0)
							{
								// In all the teams, find the one that has the ID that matched with the teamcompetingID
								me.TeamCompeting = allTeams.Where(x => x.Id == me.TeamCompetingID).First();
							}

							// Check if we have an ID of parentMatchupID
							if(me.ParentMatchupID > 0)
							{
								// In all the matchups, find the one that has the ID that matched with the parentMatchup
								me.ParentMatchup = matchups.Where(x => x.Id == me.ParentMatchupID).First();
							}
						}
					}
					// Populate Rounds List<List<MatchupMode>>
					List<MatchupModel> currentRow = new List<MatchupModel>();
					int currentRound = 1;
					foreach (MatchupModel matchup in matchups)
					{
						// if the matchupRound is 2, greater than 1, then tournament add a new matchup round, currentRow + 1
						if(matchup.MatchupRound > currentRound)
						{
							// t is tournament model
							t.Rounds.Add(currentRow);
							currentRow = new List<MatchupModel>();
							currentRound += 1;
						}
						// Round has changed
						currentRow.Add(matchup);
					}
					t.Rounds.Add(currentRow);
				}

				

				
				
				

				// Populate teams

				// Populate rounds
			}


			return output;
		}

		public void UpdateMatchup(MatchupModel model)
		{
			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
			{
				var p = new DynamicParameters();
				
				// If we have a winner, then update matchup
				if(model.Winner != null)
				{
					p.Add("@id", model.Id);
					p.Add("@winnerID", model.Winner.Id);

					connection.Execute("PROC_updateMatchups", p, commandType: CommandType.StoredProcedure);
				}

				foreach (MatchupEntryModel me in model.Entries)
				{
					// If we have a team competing , then add score to that team
					if(me.TeamCompeting != null)
					{
						p = new DynamicParameters();
						p.Add("@id", me.Id);
						p.Add("@teamCompetingID", me.TeamCompeting.Id);
						p.Add("@score", me.Score);

						connection.Execute("PROC_updateMatchupEntries", p, commandType: CommandType.StoredProcedure);
					}
				}
			}
			
		}

		public void CompleteTournament(TournamentModel model)
		{
			throw new NotImplementedException();
		}
	}
}
