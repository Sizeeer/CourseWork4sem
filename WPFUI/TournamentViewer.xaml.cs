using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using TrackerLibrary.BUL;
using TrackerLibrary.DTO;

namespace WPFUI
{
    public partial class TournamentViewer : Window
    {
        public TournamentViewer(TournamentModel model)
        {
	        InitializeComponent();

	        this.tournament = model;

	        WireUpLists();

	        LoadFormData();

	        LoadRounds();
        }
        
        private TournamentModel tournament;
		// Binding source will binding directly into binding list
		BindingList<int> rounds = new BindingList<int>();
		BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();

		private void LoadFormData()
		{
			lbTournamentName.Content = tournament.TournamentName;
		}

		private void LoadRounds()
		{
			rounds.Clear();

			rounds.Add(1);
			int currRound = 1;

			foreach (List<MatchupModel> matchups in tournament.Rounds)
			{
				if (matchups.First().MatchupRound > currRound)
				{
					currRound = matchups.First().MatchupRound;
					rounds.Add(currRound);
				}
			}

			LoadMatchupsList(1);
		}

		private void WireUpLists()
		{
		
			cbRounds.ItemsSource = rounds;	
			lstMatchup.ItemsSource = selectedMatchups;
			lstMatchup.DisplayMemberPath = "DisplayName";

		}

		

		private void cbRounds_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadMatchupsList((int)cbRounds.SelectedItem);
		}

		private void LoadMatchupsList(int round)
		{
			
			foreach (List<MatchupModel> matchups in tournament.Rounds)
			{
				if (matchups.First().MatchupRound == round)
				{
					selectedMatchups.Clear();
					foreach (MatchupModel m in matchups)
					{
						if (m.Winner == null || !Convert.ToBoolean(ckbUnplayedOnly.IsChecked))
						{
							selectedMatchups.Add(m); 
						}
					}
				}
			}

			if (selectedMatchups.Count > 0)
			{
				LoadMatchup(selectedMatchups.First()); 
			}

			DisplayMatchupInfo();
			
		}

		private void DisplayMatchupInfo()
		{
			Visibility isVisible = selectedMatchups.Count > 0 ? Visibility.Visible : Visibility.Hidden;

			lbteamOneName.Visibility = isVisible;
			lbteamTwoName.Visibility = isVisible;
			txtTeamOneScore.Visibility = isVisible;
			txtTeamTwoScore.Visibility = isVisible;
			teamOneScoreLabel.Visibility = isVisible;
			teamTwoScoreLabel.Visibility = isVisible;
			btnScore.Visibility = isVisible;
		}

		private void LoadMatchup(MatchupModel m)
		{
			if(m != null)
			{
				for (int i = 0; i < m.Entries.Count; i++)
				{
					if (i == 0)
					{
						if (m.Entries[0].TeamCompeting != null)
						{
							lbteamOneName.Content = m.Entries[0].TeamCompeting.TeamName;
							txtTeamOneScore.Text = m.Entries[0].Score.ToString();

							// To fix the problem issue with one team in "BYES TEAMS"
							lbteamTwoName.Content = "<byes>";
							txtTeamTwoScore.Text = "0";
						}
						else
						{
							lbteamOneName.Content = "Not yet set";
							txtTeamOneScore.Text = "";
						}
					}

					if (i == 1)
					{
						if (m.Entries[1].TeamCompeting != null)
						{
							lbteamTwoName.Content = m.Entries[1].TeamCompeting.TeamName;
							txtTeamTwoScore.Text = m.Entries[1].Score.ToString();
						}
						else
						{
							lbteamTwoName.Content = "Not yet set";
							txtTeamTwoScore.Text = "";
						}
					}
				}
			}
			
		}

		private void lstMatchup_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadMatchup((MatchupModel)lstMatchup.SelectedItem);
		}

		private void ckbUnplayedOnly_CheckedChanged(object sender, EventArgs e)
		{
			LoadMatchupsList((int)cbRounds.SelectedItem);
		}

		private string ValidateData()
		{
			string output = "";
			double teamOneScore = 0;
			double teamTwoScore = 0;
			bool scoreOneValid = double.TryParse(txtTeamOneScore.Text, out teamOneScore);
			bool scoreTwoValid = double.TryParse(txtTeamTwoScore.Text, out teamTwoScore);

			if(!scoreOneValid)
			{
				output = "The score One value is not a valid number";
			}
			else if(!scoreTwoValid)
			{
				output = "The score Two value is not a valid number";
			}

			else if(teamOneScore == 0 && teamTwoScore == 0)
			{
				output = "You did not enter a score for either team";
			}
			else if(teamOneScore == teamTwoScore)
			{
				output = "We do not allowed ties in this application";
			}
			return output;
		}

		private void btnScore_Click(object sender, EventArgs e)
		{
			string errorMessage = ValidateData();
			if( errorMessage.Length > 0)
			{
				MessageBox.Show($"Input error : {errorMessage}");
				return;
			}
			MatchupModel m = (MatchupModel)lstMatchup.SelectedItem;
			double teamOneScore = 0;
			double teamTwoScore = 0;
			for (int i = 0; i < m.Entries.Count; i++)
			{
				if (i == 0)
				{
					if (m.Entries[0].TeamCompeting != null)
					{
						lbteamOneName.Content = m.Entries[0].TeamCompeting.TeamName;

						bool scoreValid = double.TryParse(txtTeamOneScore.Text, out teamOneScore);

						if(scoreValid)
						{
							m.Entries[0].Score = teamOneScore;
						}
						else
						{
							MessageBox.Show("Please enter a valid score for team 1");
							return;
						}
						
					}
				}

				if (i == 1)
				{
					if (m.Entries[1].TeamCompeting != null)
					{
						lbteamTwoName.Content = m.Entries[1].TeamCompeting.TeamName;

						bool scoreValid = double.TryParse(txtTeamTwoScore.Text, out teamTwoScore);

						if (scoreValid)
						{
							m.Entries[1].Score = teamTwoScore;
						}
						else
						{
							MessageBox.Show("Please enter a valid score for team 2");
							return;
						}
					}
					
				}
			}

			try
			{
				TournamentLogic.UpdateTournamentResults(tournament);
			}
			catch(Exception ex)
			{
				MessageBox.Show($"The application had the following error : {ex.Message}");
				return;
			}

			LoadMatchupsList((int)cbRounds.SelectedItem);

			//UpdateMatchupModel(m);
		}

		private void UpdateMatchupModel(MatchupModel m)
		{
			/*TournamentViewerFormHandling handling = new TournamentViewerFormHandling();
			handling.UpdateMatchupModel(m);
			LoadMatchupsList((int)cbRounds.SelectedItem);*/

			
		}
    }
}