﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TrackerLibrary.DAL;
using TrackerLibrary.DTO;

namespace TrackerLibrary.BLL
{
	public static class TournamentLogic
	{
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
			int round = 2;
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
			
			List<MatchupModel> toScore = new List<MatchupModel>();
			
			foreach (List<MatchupModel> round in model.Rounds)
			{
				foreach (MatchupModel rm in round)
				{
					if(rm.Winner == null && (rm.Entries.Any(x => x.Score != 0) || rm.Entries.Count == 1))
					{
						toScore.Add(rm);
					}
				}
			}
			
			MarkWinnerInMatchups(toScore);
			AdvanceWinners(toScore, model);

			toScore.ForEach(x => GlobalConfig.Connection.UpdateMatchup(x));
			
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

			string to;
			string subject;
			StringBuilder body = new StringBuilder();
			
			if(competitor != null)
			{
				subject = $"Тебя ждет состязание с {competitor.TeamCompeting.TeamName}";

				body.AppendLine("<h1> У тебя новое состязание </h1> ");
				body.Append("<strong>Соперник: </strong>");
				body.Append(competitor.TeamCompeting.TeamName);
				body.AppendLine();
				body.AppendLine();
				body.AppendLine(" ~ Tournament Tracker");
			}
			else
			{
				subject = "К сожалению вы проиграли(";
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
				else
				{
					return output;
				}
			}
			CompleteTournament(model);

			return output - 1;
		}
		private static void CompleteTournament(TournamentModel model)
		{
			TeamModel winners = model.Rounds.Last().First().Winner;
			
			TeamModel runnerUp = model.Rounds.Last().First().Entries.Where(x => x.TeamCompeting != winners).First().TeamCompeting;

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

			string subject;
			StringBuilder body = new StringBuilder();

			subject = $"In {model.TournamentName}, {winners.TeamName} has won";

			body.AppendLine("<h1> У нас есть победитель! </h1> ");
			body.AppendLine("<p> Поздравляем нашего победителя");
			body.AppendLine("<br />");
			body.AppendLine(" ~ Tournament Tracker");

			if(winnerPrize > 0 )
			{
				body.AppendLine($"<p> {winners.TeamName} получает ${winnerPrize} </p>");
			}
			if(runnerUpPrize > 0)
			{
				body.AppendLine($"<p> {runnerUp.TeamName} получает ${runnerUpPrize} </p>");
			}

			body.AppendLine("<p> Спасибо за турнир! </p>");
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
			TournamentViewerFormHandling handling = new TournamentViewerFormHandling();
			handling.CompleteTournament(model);
		}
		private static float CalculatePrizePayout(this PrizeModel prize, float totalIncome)
		{
			float output;

			if(prize.PrizeAmount > 0)
			{
				output = (float)prize.PrizeAmount;
			}
			else
			{
				output = totalIncome * (prize.PrizePercentage / 100);
			}
			return output;
		}
		private static void AdvanceWinners(List<MatchupModel> models, TournamentModel tournament)
		{
			foreach (MatchupModel m in models)
			{
				foreach (List<MatchupModel> round in tournament.Rounds)
				{
					foreach (MatchupModel rm in round)
					{
						foreach (MatchupEntryModel me in rm.Entries)
						{
							if (me.ParentMatchup != null)
							{
								if (me.ParentMatchup.Id == m.Id)
								{
									me.TeamCompeting = m.Winner;
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
			string greaterWins = ConfigurationManager.AppSettings["winnerDetermination"];

			foreach (MatchupModel m in models)
			{
				if (m.Entries.Count == 1)
				{
					m.Winner = m.Entries[0].TeamCompeting;
					continue;
				}
				if (greaterWins == "0")
				{
					if(m.Entries[0].Score < m.Entries[1].Score)
					{
						m.Winner = m.Entries[0].TeamCompeting;
					}
					else if(m.Entries[1].Score < m.Entries[0].Score)
					{
						m.Winner = m.Entries[1].TeamCompeting;
					}
					else
					{
						throw new Exception("В данной версии приложения не допускается ничья");
					}
				}
				else
				{
					if (m.Entries[0].Score > m.Entries[1].Score)
					{
						m.Winner = m.Entries[0].TeamCompeting;
					}
					else if (m.Entries[1].Score > m.Entries[0].Score)
					{
						m.Winner = m.Entries[1].TeamCompeting;
					}
					else
					{
						throw new Exception("В данной версии приложения не допускается ничья");
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
			int output;
			int totalTeams = 1;

			for(int i = 1; i <= rounds; i++)
			{
				totalTeams *= 2;
			}
			output = totalTeams - numberOfTeams;
			return output;
		}
		private static int FindNumberOfRounds(int teamCount)
		{
			int output = 1, val = 2;
			
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
