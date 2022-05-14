using System;
using System.Collections.Generic;
using System.Windows;
using TrackerLibrary.BUL;
using TrackerLibrary.DTO;

namespace WPFUI
{
    public partial class CreateTournamentDashboard : Window
    {
        public CreateTournamentDashboard()
        {
            InitializeConnections initializeConnection = new InitializeConnections();
            initializeConnection.InitializeConnection();
            InitializeComponent();
            WireUpLists();
        }
        
        List<TournamentModel> _tournaments;

        private void WireUpLists()
        {
            TournamentDashboardFormHandling handling = new TournamentDashboardFormHandling();
            
            _tournaments = handling.Get_All_Tournaments();

            cbLoadExistingTournament.ItemsSource = null;
            cbLoadExistingTournament.ItemsSource = _tournaments;
            cbLoadExistingTournament.DisplayMemberPath = "tournamentName";
        }

        private void btnCreateTournament_Click(object sender, EventArgs e)
        {
            CreateTournament frm = new CreateTournament();
            frm.Show();
        }

        private void btnLoadTournament_Click(object sender, EventArgs e)
        {
            TournamentModel tm = (TournamentModel)cbLoadExistingTournament.SelectedItem;
            if(tm != null)
            {
                TournamentViewer frm = new TournamentViewer(tm);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Перед загрузкой выберите нужный турнир");
            }
			
        }
    }
}