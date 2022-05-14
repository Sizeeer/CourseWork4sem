using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary.BUL;
using TrackerLibrary.DTO;

namespace UIL
{
	public partial class frmTournamentViewer : Form
	{
		private TournamentModel tournament;
		// Binding source will binding directly into binding list
		BindingList<int> rounds = new BindingList<int>();
		BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();

		

		public frmTournamentViewer(TournamentModel model)
		{
			InitializeComponent();

			this.tournament = model;

			WireUpLists();

			LoadFormData();

			LoadRounds();


		}

		private void LoadFormData()
		{
			lbTournamentName.Text = tournament.TournamentName;
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
		
			cbRounds.DataSource = rounds;	
			lstMatchup.DataSource = selectedMatchups;
			lstMatchup.DisplayMember = "DisplayName";

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
						if (m.Winner == null || !ckbUnplayedOnly.Checked)
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
			bool isVisible = (selectedMatchups.Count > 0);

			lbteamOneName.Visible = isVisible;
			lbteamTwoName.Visible = isVisible;
			txtTeamOneScore.Visible = isVisible;
			txtTeamTwoScore.Visible = isVisible;
			versusLabel.Visible = isVisible;
			teamOneScoreLabel.Visible = isVisible;
			teamTwoScoreLabel.Visible = isVisible;
			btnScore.Visible = isVisible;
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
							lbteamOneName.Text = m.Entries[0].TeamCompeting.TeamName;
							txtTeamOneScore.Text = m.Entries[0].Score.ToString();

							// To fix the problem issue with one team in "BYES TEAMS"
							lbteamTwoName.Text = "<byes>";
							txtTeamTwoScore.Text = "0";
						}
						else
						{
							lbteamOneName.Text = "Not yet set";
							txtTeamOneScore.Text = "";
						}
					}

					if (i == 1)
					{
						if (m.Entries[1].TeamCompeting != null)
						{
							lbteamTwoName.Text = m.Entries[1].TeamCompeting.TeamName;
							txtTeamTwoScore.Text = m.Entries[1].Score.ToString();
						}
						else
						{
							lbteamTwoName.Text = "Not yet set";
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
						lbteamOneName.Text = m.Entries[0].TeamCompeting.TeamName;

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
						lbteamTwoName.Text = m.Entries[1].TeamCompeting.TeamName;

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
