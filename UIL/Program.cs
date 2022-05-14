using System;
using System.Windows.Forms;
using TrackerLibrary.BUL;

namespace UIL
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// First of all, initialize the connection 
			InitializeConnections initializeConnection = new InitializeConnections();
			initializeConnection.InitializeConnection();

			Application.Run(new frmTournamentDashboard());
		}
	}
}
