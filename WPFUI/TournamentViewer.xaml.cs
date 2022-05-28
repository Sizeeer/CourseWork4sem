using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using TrackerLibrary.BLL;
using TrackerLibrary.DTO;

namespace WPFUI
{
    public partial class TournamentViewer : Window
    {
        public TournamentViewer(TournamentModel model, ITournamentRequester callingForm)
        {
	        InitializeComponent();

	        this.tournament = model;
	        this.callingForm = callingForm;

	        WireUpLists();

	        LoadFormData();

	        LoadRounds();
        }
        
        private TournamentModel tournament;
        private ITournamentRequester callingForm;
		BindingList<int> rounds = new BindingList<int>();
		BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();
		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}
		private void LoadFormData()
		{
			lbTournamentName.Text = tournament.TournamentName;
			ckbUnplayedOnly.IsChecked = tournament.IsCompleted ? false : true;
			txtTeamOneScore.IsEnabled = tournament.IsCompleted ? false : true;
			txtTeamTwoScore.IsEnabled = tournament.IsCompleted ? false : true;
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
			btnScore.Visibility = selectedMatchups.Count > 0 && !tournament.IsCompleted ? Visibility.Visible : Visibility.Hidden;
			ckbUnplayedOnly.Visibility = tournament.IsCompleted ? Visibility.Hidden : Visibility.Visible;
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

							lbteamTwoName.Content = "<не найдено>";
							txtTeamTwoScore.Text = "0";
						}
						else
						{
							lbteamOneName.Content = "Не найдено";
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
							lbteamTwoName.Content = "Не найдено";
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

		private List<string> ValidateData()
		{
			List<string> errorMessages = new List<string>();
			double teamOneScore;
			double teamTwoScore;
			bool scoreOneValid = double.TryParse(txtTeamOneScore.Text, out teamOneScore);
			bool scoreTwoValid = double.TryParse(txtTeamTwoScore.Text, out teamTwoScore);

			if(!scoreOneValid)
			{
				errorMessages.Add("Очки первой команды должны быть числом");
			}
			else if(!scoreTwoValid)
			{
				errorMessages.Add("Очки второй команды должны быть числом");
			}
			else if (teamOneScore < 0 || teamTwoScore < 0)
			{
				errorMessages.Add("Очки должны быть равны 0 или более");
			}

			else if(teamOneScore == 0 && teamTwoScore == 0)
			{
				errorMessages.Add("Не выбран победитель");
			}
			else if(teamOneScore == teamTwoScore)
			{
				errorMessages.Add("В текущей версии приложения не может быть ничьей");
			}

			return errorMessages;
		}
		private void btnScore_Click(object sender, EventArgs e)
		{
			List<string> errorMessages = ValidateData();
			if( errorMessages.Count == 0)
			{
				MatchupModel m = lstMatchup.SelectedItem != null ? (MatchupModel)lstMatchup.SelectedItem : (MatchupModel)lstMatchup.Items.GetItemAt(0);
				double teamOneScore;
				double teamTwoScore;
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
								MessageBox.Show("Пожалуйста, введите валидные данные для очков 1 команды");
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
								MessageBox.Show("Пожалуйста, введите валидные данные для очков 2 команды");
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
					MessageBox.Show(ex.Message);
					return;
				}

				LoadMatchupsList((int)cbRounds.SelectedItem);

				UpdateMatchupModel(m);
			}
			else
			{
				MessageBox.Show(String.Join("\n", errorMessages));
			}
		}
		private void UpdateMatchupModel(MatchupModel m)
		{
			TournamentViewerFormHandling handling = new TournamentViewerFormHandling();
			handling.UpdateMatchupModel(m);
			if (cbRounds.SelectedIndex + 1 == cbRounds.Items.Count)
			{
				MessageBox.Show("Турнир окончен");
				callingForm.TournamentComplete();
				this.Close();
			}
			else
			{
				LoadMatchupsList((int)cbRounds.SelectedItem);
			}
		}
    }
}