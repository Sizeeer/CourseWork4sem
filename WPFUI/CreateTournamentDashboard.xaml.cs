using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using TrackerLibrary.BLL;
using TrackerLibrary.DTO;

namespace WPFUI
{
    public partial class CreateTournamentDashboard : Window, ITournamentRequester
    {
        public CreateTournamentDashboard()
        {
            InitializeConnections initializeConnection = new InitializeConnections();
            initializeConnection.InitializeConnection();
            InitializeComponent();


            App.LanguageChanged += LanguageChanged;

            CultureInfo currLang = App.Language;

            menuLanguage.Items.Clear();
            foreach (var lang in App.Languages)
            {
                MenuItem menuLang = new MenuItem();
                menuLang.Header = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsChecked = lang.Equals(currLang);
                menuLang.Click += ChangeLanguageClick;
                menuLanguage.Items.Add(menuLang);
            }

            WireUpLists();
        }

        private void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;


            foreach (MenuItem i in menuLanguage.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsChecked = ci != null && ci.Equals(currLang);
            }
        }

        private void ChangeLanguageClick(Object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    App.Language = lang;
                }
            }

        }

        List<TournamentModel> _tournaments;
        TournamentDashboardFormHandling handling = new TournamentDashboardFormHandling();

        private void WireUpLists()
        {
            _tournaments = handling.Get_All_Tournaments();

            cbLoadExistingTournament.ItemsSource = null;
            cbLoadExistingTournament.ItemsSource = _tournaments;
            cbLoadExistingTournament.DisplayMemberPath = "TournamentName";
        }

        private void btnCreateTournament_Click(object sender, EventArgs e)
        {
            CreateTournament frm = new CreateTournament(this);
            frm.Show();
        }
        
        private void btnDeleteTournament_Click(object sender, EventArgs e)
        {
            TournamentModel tm = (TournamentModel)cbLoadExistingTournament.SelectedItem;
            if(tm != null)
            {
                handling.DeleteTournament(tm);
                WireUpLists();
            }
            else
            {
                MessageBox.Show("Перед удалением выберите нужный турнир");
            }
        }

        private void btnLoadTournament_Click(object sender, EventArgs e)
        {
            TournamentModel tm = (TournamentModel)cbLoadExistingTournament.SelectedItem;
            if(tm != null)
            {
                TournamentViewer frm = new TournamentViewer(tm, this);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Перед загрузкой выберите нужный турнир");
            }
        }

        public void TournamentComplete()
        {
            WireUpLists();
        }
    }
}