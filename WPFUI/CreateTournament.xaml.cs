using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using TrackerLibrary.BLL;
using TrackerLibrary.DTO;

namespace WPFUI
{
    public partial class CreateTournament : Window, IPrizeRequester, ITeamRequester
    {
        public CreateTournament(ITournamentRequester caller)
        {
	        InitializeComponent();
	        Load_Data();
	        WireUpLists();
	        _caller = caller;
        }

        ITournamentRequester _caller;
        List<TeamModel> availableTeams = new List<TeamModel>();
		List<TeamModel> selectedTeams = new List<TeamModel>();
		public List<PrizeModel> selectedPrizes { get; set; } = new List<PrizeModel>();

		private void Load_Data()
		{
			CreateTournamentFormHandling createTournamentFormHandling = new CreateTournamentFormHandling();

			availableTeams = createTournamentFormHandling.Get_All_Teams();
		}

		private void WireUpLists()
		{
			cbSelectTeam.ItemsSource = null;
			cbSelectTeam.ItemsSource = availableTeams;
			cbSelectTeam.DisplayMemberPath = "TeamName";

			lstTournamentTeams.ItemsSource = null;
			lstTournamentTeams.ItemsSource = selectedTeams;
			lstTournamentTeams.DisplayMemberPath = "TeamName";

			lstPrizes.ItemsSource = null;
			lstPrizes.ItemsSource = selectedPrizes;
			lstPrizes.DisplayMemberPath = "PlaceName";
		}

		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}

		private void btnAddTeam_Click(object sender, EventArgs e)
		{
			TeamModel t = (TeamModel)cbSelectTeam.SelectedItem;

			if(t != null)
			{
				availableTeams.Remove(t);
				selectedTeams.Add(t);
			}
			WireUpLists();
		}

		private void btnCreatePrize_Click(object sender, EventArgs e)
		{
			CreatePrize frm = new CreatePrize(this);
			frm.Show();
		}

		public void PrizeComplete(PrizeModel p)
		{
			selectedPrizes.Add(p);
			WireUpLists();
		}

		public void TeamComplete(TeamModel t)
		{
			selectedTeams.Add(t);
			WireUpLists();
		}

		private void btnCreateTeam_Click(object sender, EventArgs e)
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

		private List<string> ValidateData()
		{
			List<string> erorrMessages = new List<string>();

			if (txtTournamentName.Text.Length == 0)
			{
				erorrMessages.Add("Название турнира обязательно");
			}
			else if(lstTournamentTeams.Items.Count < 2)
			{
				erorrMessages.Add("Должно быть минимум 2 команды");
			}
			else if(lstPrizes.Items.Count < 2)
			{
				erorrMessages.Add("Должно быть минимум 2 приза");
			}

			return erorrMessages;
		}

		private void btnCreateTournament_Click(object sender, EventArgs e)
		{
			List<string> errorMessages = ValidateData();
			if (errorMessages.Count == 0)
			{
				float fee;
				bool feeAcceptable = float.TryParse(txtEntryFee.Text, out fee);

				if(!feeAcceptable)
				{
					MessageBox.Show("Введите валидное взначение взноса");
				}
				else
				{
					TournamentModel tm = new TournamentModel();
					tm.TournamentName = txtTournamentName.Text;
					tm.EntryFee = fee;

					tm.Prizes = selectedPrizes;
					tm.EnteredTeams = selectedTeams;
					tm.IsCompleted = false;

					TournamentLogic.CreateRounds(tm);
				
					CreateTournamentFormHandling createTournamentFormHandling = new CreateTournamentFormHandling();
					createTournamentFormHandling.CreateTournament(tm);

					TournamentLogic.UpdateTournamentResults(tm);

					TournamentViewer frm = new TournamentViewer(tm, _caller);
					frm.Show();
					_caller.TournamentComplete();
					this.Close();
				}
			}
			else
			{
				MessageBox.Show(String.Join("\n", errorMessages));
			}
		}

        private void selectAllTeams_Click(object sender, RoutedEventArgs e)
        {
			foreach(var item in cbSelectTeam.Items)
            {
				if (item != null)
				{
					selectedTeams.Add(item as TeamModel);
				}
			}
			availableTeams.Clear();
			WireUpLists();
		}

        
    }
}