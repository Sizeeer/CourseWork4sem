using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TrackerLibrary.DAL;
using TrackerLibrary.DTO;

namespace TrackerLibrary.BUL
{
	public static class TournamentLogic
	{
		// Order out list randomly
		// Check if it is big enough - if not, add it in byes - 2 * 2 * 2 * 2 - 2^4
		// Create our first round of matchup
		// Create every round after that - 8 matchups - 4 matchups - 2 matchups - 1 matchup

		public static void CreateRounds(TournamentModel model)
		{
			List<TeamModel> randomizedTeams = RandomizeTeamOrder(model.EnteredTeams);
			int rounds = FindNumberOfRounds(randomizedTeams.Count);
			int byes = NumberOfByes(rounds, randomizedTeams.Count);

			model.Rounds.Add(CreateFirstRound(byes, randomizedTeams));

			CreateOtherRounds(model, rounds);

			UpdateTournamentResults(model);
		}

		private static void CreateOtherRounds(TournamentModel model, int rounds)
		{
			// if we have 8 matchup in the previous round, we have 4 matchup in the current round and so on
			int round = 2;
			// List<List<MatchupModel>> Rounds 
			// Get the first list of matchup model
			List<MatchupModel> previousRound = model.Rounds[0];
			List<MatchupModel> currentRound = new List<MatchupModel>();
			MatchupModel currentMatchup = new MatchupModel();

			while(round <= rounds)
			{
				foreach (MatchupModel match in previousRound)
				{
					currentMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup = match });
					
					if(currentMatchup.Entries.Count > 1 )
					{
						currentMatchup.MatchupRound = round;
						currentRound.Add(currentMatchup);
						currentMatchup = new MatchupModel();
					}
				}
				model.Rounds.Add(currentRound);
				previousRound = currentRound;

				currentRound = new List<MatchupModel>();
				round += 1;
			}
		}
		
		public static void UpdateTournamentResults(TournamentModel model)
		{
			int startingMatchup = model.CheckCurrentRound();
			// this is the matchup we need to score
			List<MatchupModel> toScore = new List<MatchupModel>();
			// when this loop is completed, I have knowed which one need to be scored 
			foreach (List<MatchupModel> round in model.Rounds)
			{
				foreach (MatchupModel rm in round)
				{
					// Check to see if there is any entries have a score != 0
					// if we complete a match, we put the values of toSore in
					// If we already scored, we already have a winner, we ignored this stuff
					if(rm.Winner == null && (rm.Entries.Any(x => x.Score != 0) || rm.Entries.Count == 1))
					{
						toScore.Add(rm);
					}
				}
			}
			MarkWinnerInMatchups(toScore);
			AdvanceWinners(toScore, model);

			// For every toscore, done this line : DAL.GlobalConfig.Connection.UpdateMatchup(m);
			toScore.ForEach(x => GlobalConfig.Connection.UpdateMatchup(x));

			// its the same

			/*foreach (MatchupModel x in toScore)
			{
				GlobalConfig.Connection.UpdateMatchup(x);
			}*/
			int endingRound = model.CheckCurrentRound();

			if(endingRound > startingMatchup)
			{
				model.AlertUsersToNewRound();
			}
		} 

		public static void AlertUsersToNewRound(this TournamentModel model)
		{
			int currentRoundNumber = model.CheckCurrentRound();
			List<MatchupModel> currentRound = model.Rounds.Where(x => x.First().MatchupRound == currentRoundNumber).First();

			foreach (MatchupModel matchup in currentRound)
			{
				foreach (MatchupEntryModel me in matchup.Entries)
				{
					foreach (PersonModel p in me.TeamCompeting.TeamMembers)
					{
						// In the parent matchup I know we have two team competing therefore the other's team that's competing and I'll says 
						AlertPersonToNewRound(p, me.TeamCompeting.TeamName, matchup.Entries.Where(x => x.TeamCompeting != me.TeamCompeting).FirstOrDefault());
					}
				}
			}
		}

		private static void AlertPersonToNewRound(PersonModel p, string teamName, MatchupEntryModel competitor)
		{
			if(p.EmailAddress.Length == 0)
			{
				return; 
			}

			string to = "";
			string subject = "";
			StringBuilder body = new StringBuilder();
			
			if(competitor != null)
			{
				subject = $"You have a new matchup with {competitor.TeamCompeting.TeamName}";

				body.AppendLine("<h1> You have a new matchup </h1> ");
				body.Append("<strong>Competitor: </strong>");
				body.Append(competitor.TeamCompeting.TeamName);
				body.AppendLine();
				body.AppendLine();
				body.AppendLine("Have a great time !");
				body.AppendLine(" ~ Tournament Tracker");
			}
			else
			{
				subject = "You have a bye week this round";

				body.AppendLine("Enjoy your round off !");
				body.AppendLine(" ~ Tournament Tracker ");
			}

			to = p.EmailAddress;

			EmailLogic.SendEmail(to, subject, body.ToString());
		}

		private static int CheckCurrentRound(this TournamentModel model)
		{
			int output = 1;
			foreach (List<MatchupModel> round in model.Rounds)
			{
				if (round.All(x => x.Winner != null))
				{
					output += 1;
				}
				// If we find one round that contains no winner, return output, wthich give the same value as before
				else
				{
					return output;
				}
			}
			// Tournament is complete
			CompleteTournament(model);

			// This include the last round, so may be ouput will be += 1, we dont want that
			return output - 1;
		}

		private static void CompleteTournament(TournamentModel model)
		{
			// last round of my list is a list of matchup
			TeamModel winners = model.Rounds.Last().First().Winner;

			// get the last round, there are 2 entry, we already have a winner
			// give me the one that team competing is not the winner
			TeamModel runnerUp = model.Rounds.Last().First().Entries.Where(x => x.TeamCompeting != winners).First().TeamCompeting;

			// only have 2 value
			float winnerPrize = 0;
			float runnerUpPrize = 0;

			if(model.Prizes.Count > 0 )
			{
				float totalIncome = model.EnteredTeams.Count * model.EntryFee;

				PrizeModel firstPlacePrize = model.Prizes.Where(x => x.PlaceNumber == 1).FirstOrDefault();
				PrizeModel secondPlacePrize = model.Prizes.Where(x => x.PlaceNumber == 2).FirstOrDefault();
				if (firstPlacePrize != null)
				{
					winnerPrize = firstPlacePrize.CalculatePrizePayout(totalIncome);
				}
				if (secondPlacePrize != null)
				{
					runnerUpPrize = secondPlacePrize.CalculatePrizePayout(totalIncome);
				}
			}

			// Send email to our tournament
			string subject = "";
			StringBuilder body = new StringBuilder();

			subject = $"In {model.TournamentName}, {winners.TeamName} has won";

			body.AppendLine("<h1> We have a winner </h1> ");
			body.AppendLine("<p> Congratulations to our winner on a great tournament");
			body.AppendLine("<br />");
			body.AppendLine();
			body.AppendLine();
			body.AppendLine("Have a great time !");
			body.AppendLine(" ~ Tournament Tracker");

			if(winnerPrize > 0 )
			{
				body.AppendLine($"<p> {winners.TeamName} wil receive ${winnerPrize} </p>");
			}
			if(runnerUpPrize > 0)
			{
				body.AppendLine($"<p> {runnerUp.TeamName} wil receive ${runnerUpPrize} </p>");
			}

			body.AppendLine("<p> Thanks for a great tornament everyone ! </p>");
			body.AppendLine(" ~ Tournament Tracker ");

			List<string> bcc = new List<string>();
			foreach (TeamModel t in model.EnteredTeams)
			{
				foreach (PersonModel p in t.TeamMembers)
				{
					if(p.EmailAddress.Length > 0)
					{
						bcc.Add(p.EmailAddress);
					}
				}
			}
			EmailLogic.SendEmail(new List<string>(), bcc, subject, body.ToString());
		}

		private static float CalculatePrizePayout(this PrizeModel prize, float totalIncome)
		{
			float output = 0;

			if(prize.PrizeAmount > 0)
			{
				output = (float)prize.PrizeAmount;
			}
			else
			{
				// 50 / 100 = 0.5
				// Multiply 2 decimal
				output = totalIncome * (prize.PrizePercentage / 100);
			}
			return output;
		}

		private static void AdvanceWinners(List<MatchupModel> models, TournamentModel tournament)
		{
			foreach (MatchupModel m in models)
			{
				// The winner team is also the parent team
				foreach (List<MatchupModel> round in tournament.Rounds)
				{
					foreach (MatchupModel rm in round)
					{
						foreach (MatchupEntryModel me in rm.Entries)
						{
							if (me.ParentMatchup != null)
							{
								// We using parentMatchupID because in the fact of we're trying to pull the ID from tournament model instead of database, ID will be null
								if (me.ParentMatchup.Id == m.Id)
								{
									// we can put that team in the team competing in the next round
									me.TeamCompeting = m.Winner;
									// we modified rm not m 
									GlobalConfig.Connection.UpdateMatchup(rm);
								}
							}
						}
					}
				}
			}
			
		}

		private static void MarkWinnerInMatchups(List<MatchupModel> models)
		{
			// key : winner, value : greater or lesser
			string greaterWins = ConfigurationManager.AppSettings["winnerDetermination"];

			foreach (MatchupModel m in models)
			{
				// if we have one entry	, check for bye week entry
				if (m.Entries.Count == 1)
				{
					m.Winner = m.Entries[0].TeamCompeting;
					continue;
				}
				// 0 means false, or low score wins
				if (greaterWins == "0")
				{
					if(m.Entries[0].Score < m.Entries[1].Score)
					{
						// if the first winner entry score, so the winner is the first entry
						m.Winner = m.Entries[0].TeamCompeting;
					}
					else if(m.Entries[1].Score < m.Entries[0].Score)
					{
						m.Winner = m.Entries[1].TeamCompeting;
					}
					else
					{
						throw new Exception("We do not allowed tie score in this applcation");
					}
				}
				// else means score wins
				else
				{
					if (m.Entries[0].Score > m.Entries[1].Score)
					{
						// if the first winner entry score, so the winner is the first entry
						m.Winner = m.Entries[0].TeamCompeting;
					}
					else if (m.Entries[1].Score > m.Entries[0].Score)
					{
						m.Winner = m.Entries[1].TeamCompeting;
					}
					else
					{
						throw new Exception("We do not allowed tie score in this applcation");
					}
				}
			}
					
		}

		private static List<MatchupModel> CreateFirstRound(int byes, List<TeamModel>teams)
		{
			List<MatchupModel> output = new List<MatchupModel>();
			MatchupModel curr = new MatchupModel();

			foreach(TeamModel team in teams)
			{
				curr.Entries.Add(new MatchupEntryModel { TeamCompeting = team });
				if(byes > 0 || curr.Entries.Count > 1)
				{
					curr.MatchupRound = 1;
					output.Add(curr);
					curr = new MatchupModel();

					if(byes > 0)
					{
						byes -= 1;
					}
				}

			}
			return output;
		}

		private static int NumberOfByes(int rounds, int numberOfTeams)
		{
			int output = 0;
			int totalTeams = 1;

			// rounds = 2
			// from 1 -> 2, totalTeams = 4
			// After ending the for loop, The number of byes is equal to (totalTeams - NumberOFTeams)
			// 4 - 3 = 1
			// So we have one byes
			for(int i = 1; i <= rounds; i++)
			{
				totalTeams *= 2;
			}
			output = totalTeams - numberOfTeams;
			return output;
		}
		private static int FindNumberOfRounds(int teamCount)
		{
			int output = 1;
			int val = 2;

			// if val < teamCount, it means we must have at least 2 team wins in round 1 to open round 2
			// Return output = 2 (Matchup round is 2)
			while (val < teamCount)
			{
				output += 1;
				val *= 2;
			}

			return output;
		}

		private static List<TeamModel> RandomizeTeamOrder(List<TeamModel>teams)
		{
			return teams.OrderBy(x => Guid.NewGuid()).ToList();
		}
	}
}
