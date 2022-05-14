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
	public partial class frmTournamentDashboard : Form
	{
		List<TournamentModel> tournaments;
		public frmTournamentDashboard()
		{
			InitializeComponent();
			WireUpLists();
		}

		private void WireUpLists()
		{
			TournamentDashboardFormHandling handling = new TournamentDashboardFormHandling();

			// Get all teams and insert those teams into list of team model called availableTeams
			tournaments = handling.Get_All_Tournaments();

			cbLoadExistingTournament.DataSource = null;
			cbLoadExistingTournament.DataSource = tournaments;
			cbLoadExistingTournament.DisplayMember = "tournamentName";
		}

		private void btnCreateTournament_Click(object sender, EventArgs e)
		{
			frmCreateTournament frm = new frmCreateTournament();
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
				frmTournamentViewer frm = new frmTournamentViewer(tm);
				frm.Show();
			}
			
		}
	}
}
