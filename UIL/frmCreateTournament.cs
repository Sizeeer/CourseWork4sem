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
	public partial class frmCreateTournament : Form, IPrizeRequester, ITeamRequester
	{
		List<TeamModel> availableTeams = new List<TeamModel>();
		List<TeamModel> selectedTeams = new List<TeamModel>();
		List<PrizeModel> selectedPrizes = new List<PrizeModel>();
		public frmCreateTournament()
		{
			InitializeComponent();

			Load_Data();
			WireUpLists();
		}

		private void Load_Data()
		{
			CreateTournamentFormHandling createTournamentFormHandling = new CreateTournamentFormHandling();

			// Get all teams and insert those teams into list of team model called availableTeams
			availableTeams = createTournamentFormHandling.Get_All_Teams();
		}

		private void WireUpLists()
		{
			cbSelectTeam.DataSource = null;
			cbSelectTeam.DataSource = availableTeams;
			cbSelectTeam.DisplayMember = "TeamName";
			// select the propery of availableTeams to display on the combo box

			lstTournamentTeams.DataSource = null;
			lstTournamentTeams.DataSource = selectedTeams;
			lstTournamentTeams.DisplayMember = "TeamName";

			lstPrizes.DataSource = null;
			lstPrizes.DataSource = selectedPrizes;
			lstPrizes.DisplayMember = "PlaceName";
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
			frmCreatePrize frm = new frmCreatePrize(this);
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

		private void linklbCreateNewTeam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			frmCreateTeam frm = new frmCreateTeam(this);
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
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
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

			
			

			frmTournamentViewer frm = new frmTournamentViewer(tm);
			frm.Show();
			this.Close();

		}
	}
}
