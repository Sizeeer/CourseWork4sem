using System;
using System.Collections.Generic;
using System.Windows;
using TrackerLibrary.BUL;
using TrackerLibrary.DTO;

namespace WPFUI
{
    public partial class CreateTournament : Window, IPrizeRequester, ITeamRequester
    {
        public CreateTournament()
        {
	        InitializeComponent();

	        Load_Data();
	        WireUpLists();
        }
        
        List<TeamModel> availableTeams = new List<TeamModel>();
		List<TeamModel> selectedTeams = new List<TeamModel>();
		List<PrizeModel> selectedPrizes = new List<PrizeModel>();

		private void Load_Data()
		{
			CreateTournamentFormHandling createTournamentFormHandling = new CreateTournamentFormHandling();

			// Get all teams and insert those teams into list of team model called availableTeams
			availableTeams = createTournamentFormHandling.Get_All_Teams();
		}

		private void WireUpLists()
		{
			cbSelectTeam.ItemsSource = null;
			cbSelectTeam.ItemsSource = availableTeams;
			cbSelectTeam.DisplayMemberPath = "TeamName";
			// select the propery of availableTeams to display on the combo box

			lstTournamentTeams.ItemsSource = null;
			lstTournamentTeams.ItemsSource = selectedTeams;
			lstTournamentTeams.DisplayMemberPath = "TeamName";

			lstPrizes.ItemsSource = null;
			lstPrizes.ItemsSource = selectedPrizes;
			lstPrizes.DisplayMemberPath = "PlaceName";
		}

		private void btnAddTeam_Click(object sender, EventArgs e)
		{
			TeamModel t = (TeamModel)cbSelectTeam.SelectedItem;

			// If t == null, dont do anything
			if(t != null)
			{
				availableTeams.Remove(t);
				selectedTeams.Add(t);
			}
			WireUpLists();
		}

		private void btnCreatePrize_Click(object sender, EventArgs e)
		{
			// Call the create prize form
			CreatePrize frm = new CreatePrize(this);
			frm.Show();

			
		}

		public void PrizeComplete(PrizeModel p)
		{
			// Get back from the form a prize model

			// Take the prize model to the list
			selectedPrizes.Add(p);
			WireUpLists();
		}

		public void TeamComplete(TeamModel t)
		{
			selectedTeams.Add(t);
			WireUpLists();
		}

		private void linklbCreateNewTeam_LinkClicked(object sender, EventArgs e)
		{
			CreateTeam frm = new CreateTeam(this);
			frm.Show();
		}

		private void btnRemoveSelectedPlayers_Click(object sender, EventArgs e)
		{
			TeamModel t = (TeamModel)lstTournamentTeams.SelectedItem;
			if(t != null)
			{
				selectedTeams.Remove(t);
				availableTeams.Add(t);
				WireUpLists();
			}
		}

		private void btnRemoveSelectedPrizes_Click(object sender, EventArgs e)
		{
			PrizeModel p = (PrizeModel)lstPrizes.SelectedItem;
			if(p != null)
			{
				selectedPrizes.Remove(p);
				WireUpLists();
			}
		}

		private string ValidateData()
		{
			string output = "";

			if (txtTournamentName.Text.Length == 0)
			{
				output = "You must enter a tournament name";
			}
			else if(lstTournamentTeams.Items.Count < 2)
			{
				output = "You must have at least 2 teams";
			}
			else if(lstPrizes.Items.Count < 2)
			{
				output = "You must have at least 2 prizes";
			}
			
			return output;
			
		}

		private void btnCreateTournament_Click(object sender, EventArgs e)
		{
			string errorMessage = ValidateData();
			if (errorMessage.Length > 0)
			{
				MessageBox.Show($"Input error : {errorMessage}");
				return;
			}

			// Validate data
			float fee = 0;
			bool feeAcceptable = float.TryParse(txtEntryFee.Text, out fee);

			if(!feeAcceptable)
			{
				MessageBox.Show("You need to enter a valid entry fee ", 
					"Invalid fee", 
					MessageBoxButton.OK,
					MessageBoxImage.Error);
				return;
			}

			// Create Tournament entry
			TournamentModel tm = new TournamentModel();
			tm.TournamentName = txtTournamentName.Text;
			// using try parse to not to expled
			tm.EntryFee = fee;

			tm.Prizes = selectedPrizes;
			tm.EnteredTeams = selectedTeams;

			// Wire our matchup
			TournamentLogic.CreateRounds(tm);

			// Create all the prizes entries
			// Create all of the teams entries
			CreateTournamentFormHandling createTournamentFormHandling = new CreateTournamentFormHandling();
			createTournamentFormHandling.CreateTournament(tm);

			TournamentLogic.UpdateTournamentResults(tm);

			
			

			TournamentViewer frm = new TournamentViewer(tm);
			frm.Show();
			this.Close();

		}
    }
}