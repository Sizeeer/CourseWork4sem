using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using TrackerLibrary.DTO;

namespace TrackerLibrary.DAL
{
    public class SqlConnector: IDataConnection
    {
        private const string db = "TournamentManagement";
        public PrizeModel CreatePrize(PrizeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@placeNumber", model.PlaceNumber);
                p.Add("@placeName", model.PlaceName);
                p.Add("@prizeAmount", model.PrizeAmount);
                p.Add("@prizePercentage", model.PrizePercentage);
                p.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("insertPrizes", p, commandType: CommandType.StoredProcedure);
                model.Id = p.Get<int>("@id");
            }
            return model;
        }
        public PersonModel CreatePeople(PersonModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@firstName", model.FirstName);
                p.Add("@lastName", model.LastName);
                p.Add("@emailAddress", model.EmailAddress);
                p.Add("@phoneNumber", model.CellPhoneNumber);
                p.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("insertPeople", p, commandType: CommandType.StoredProcedure);
                model.Id = p.Get<int>("@id");
            }
            return model;
        }
        public TeamModel CreateTeam(TeamModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@teamName", model.TeamName);
                p.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("PROC_insertTeams", p, commandType: CommandType.StoredProcedure);
                model.Id = p.Get<int>("@id");

                foreach (PersonModel person in model.TeamMembers)
                {
                    p = new DynamicParameters();
                    p.Add("@teamID", model.Id);
                    p.Add("@personID", person.Id);
                    p.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);

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
            var p = new DynamicParameters();
            p.Add("@tournamentName", model.TournamentName);
            p.Add("@entryFee", model.EntryFee);
            p.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("@isCompleted", value: model.IsCompleted, dbType: DbType.Boolean);

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
                p.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("PROC_insert_TournamentPrizes", p, commandType: CommandType.StoredProcedure);
            }
        }
        private void SaveTournamentEntries(TournamentModel model, IDbConnection connection)
        {
            foreach (TeamModel t in model.EnteredTeams)
            {
                var p = new DynamicParameters();
                p.Add("@tournamentID", model.Id);
                p.Add("@teamID", t.Id);
                p.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("PROC_insert_TournamentEntries", p, commandType: CommandType.StoredProcedure);
            }
        }
        private void SaveTournamentRounds(TournamentModel model, IDbConnection connection)
        {
            foreach (List<MatchupModel> round in model.Rounds)
            {
                foreach (MatchupModel matchup in round)
                {
                    var p = new DynamicParameters();
                    p.Add("@tournamentID", model.Id);
                    p.Add("@matchupRound", matchup.MatchupRound);
                    p.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connection.Execute("PROC_insertMatchups", p, commandType: CommandType.StoredProcedure);

                    matchup.Id = p.Get<int>("@id");

                    foreach (MatchupEntryModel entry in matchup.Entries)
                    {
                        p = new DynamicParameters();
                        p.Add("@matchupID", matchup.Id);

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
                        p.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                        connection.Execute("PROC_insertMatchupEntries", p, commandType: CommandType.StoredProcedure);
                        entry.Id = p.Get<int>("@id");
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
                    t.Prizes = connection.Query<PrizeModel>("PROC_selectPrizes_GetByTournament", p,
                        commandType: CommandType.StoredProcedure).ToList();

                    p = new DynamicParameters();
                    p.Add("@tournamentID", t.Id);
                    t.EnteredTeams = connection.Query<TeamModel>("PROC_selectTeams_GetByTournament", p,
                        commandType: CommandType.StoredProcedure).ToList();

                    foreach (TeamModel team in t.EnteredTeams)
                    {
                        p = new DynamicParameters();
                        p.Add("@teamID", team.Id);
                        team.TeamMembers = connection.Query<PersonModel>("PROC_selectTeamMembers_GetByTeam", p,
                            commandType: CommandType.StoredProcedure).ToList();
                    }

                    p = new DynamicParameters();
                    p.Add("@tournamentID", t.Id);
                    List<MatchupModel> matchups = connection.Query<MatchupModel>("PROC_selectMatchups_GetByTournament",
                        p, commandType: CommandType.StoredProcedure).ToList();

                    foreach (MatchupModel matchup in matchups)
                    {
                        p = new DynamicParameters();
                        p.Add("@matchupID", matchup.Id);
                        matchup.Entries = connection.Query<MatchupEntryModel>("PROC_selectMatchupEntries_GetByMatchup",
                            p, commandType: CommandType.StoredProcedure).ToList();

                        List<TeamModel> allTeams = Get_All_Teams();

                        if (matchup.WinnerID > 0)
                        {
                            matchup.Winner = allTeams.Where(x => x.Id == matchup.WinnerID).First();
                        }

                        foreach (var me in matchup.Entries)
                        {
                            if (me.TeamCompetingID > 0)
                            {
                                me.TeamCompeting = allTeams.Where(x => x.Id == me.TeamCompetingID).First();
                            }

                            if (me.ParentMatchupID > 0)
                            {
                                me.ParentMatchup = matchups.Where(x => x.Id == me.ParentMatchupID).First();
                            }
                        }
                    }

                    List<MatchupModel> currentRow = new List<MatchupModel>();
                    int currentRound = 1;
                    foreach (MatchupModel matchup in matchups)
                    {
                        if (matchup.MatchupRound > currentRound)
                        {
                            t.Rounds.Add(currentRow);
                            currentRow = new List<MatchupModel>();
                            currentRound += 1;
                        }

                        currentRow.Add(matchup);
                    }

                    t.Rounds.Add(currentRow);
                }
            }

            return output;
        }
        public void UpdateMatchup(MatchupModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();

                if (model.Winner != null)
                {
                    p.Add("@id", model.Id);
                    p.Add("@winnerID", model.Winner.Id);

                    connection.Execute("PROC_updateMatchups", p, commandType: CommandType.StoredProcedure);
                }

                foreach (MatchupEntryModel me in model.Entries)
                {
                    if (me.TeamCompeting != null)
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
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@id", value: model.Id);
                connection.Execute("PROC_completeTournament", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteTournament(TournamentModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@id", value: model.Id);
                connection.Execute("PROC_deleteTournament", p, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
