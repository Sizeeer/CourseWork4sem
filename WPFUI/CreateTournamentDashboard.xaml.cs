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
            // First of all, initialize the connection 
            InitializeConnections initializeConnection = new InitializeConnections();
            initializeConnection.InitializeConnection();
            InitializeComponent();
            WireUpLists();
        }
        
        List<TournamentModel> tournaments;

        private void WireUpLists()
        {
            TournamentDashboardFormHandling handling = new TournamentDashboardFormHandling();

            // Get all teams and insert those teams into list of team model called availableTeams
            tournaments = handling.Get_All_Tournaments();

            cbLoadExistingTournament.ItemsSource = null;
            cbLoadExistingTournament.ItemsSource = tournaments;
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
            if(tm == null)
            {
                MessageBox.Show("You can not load a tournament becase you don't have it !");
            }
            else
            {
                TournamentViewer frm = new TournamentViewer(tm);
                frm.Show();
            }
			
        }
    }
}